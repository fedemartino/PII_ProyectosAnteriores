using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PainterLib;
using UcuLifeLib.Listener;

namespace UcuLifeLib
{
    /// <summary>
    /// La interfaz principal de UcuLife.
    /// </summary>
    /// <remarks>
    /// La interfaz provee ademas los servicios de un ejecutor de acciones, para
    /// simplificar problemas de sincronizacion entre las acciones y los eventos 
    /// de usuario.
    /// Pueden agregarse acciones en cualquier momento, pero las acciones agregadas
    /// a la interfaz, se comienzan a ejecutar luego de que se invoque al metodo 
    /// <code>Run()</code>
    /// </remarks>
    public sealed partial class MainGui : FormBoard, IMainGui, IExecutor
    {
        private sealed class Point : IPoint
        {
            private readonly Int32 x;
            private readonly Int32 y;
            public Point(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }
            public int X { get { return x; } }
            public int Y { get { return y; } }
        }

        private readonly IDictionary<Type, IList<IListener>> listeners = new Dictionary<Type, IList<IListener>>();

        private readonly IList<String> worlds = new List<String>();

        private readonly IDictionary<MenuItem, String> worldsByMenu = new Dictionary<MenuItem, String>();

        private readonly IList<String> things = new List<String>();

        private readonly IDictionary<MenuItem, String> thingsByMenu = new Dictionary<MenuItem, String>();

        private readonly MenuItem mnuWorlds;

        private readonly MenuItem mnuThings;
        
        private readonly GuiExecutor executor;

        private delegate void Notification<T>(T listener);

        /// <summary>
        /// Crea una nueva ventana de usuario.
        /// </summary>
        /// <param name="width">El ancho</param>
        /// <param name="height">El alto</param>
        public MainGui(Int32 width, Int32 height)
            : base(width, height)
        {
            InitializeComponent();
            
            MenuItem mnuFile = new MenuItem("&File");
            mnuFile.MenuItems.Add(new MenuItem("E&xit", 
                new EventHandler(mnuFileExit_Click),
                Shortcut.CtrlX));

            mnuWorlds = new MenuItem("&Worlds");            
            mnuWorlds.MenuItems.Add(new MenuItem("&Play/Pause", 
                new EventHandler(mnuPlayPause_Click),
                Shortcut.CtrlP));
            mnuWorlds.MenuItems.Add("-");
            
            mnuThings = new MenuItem("&Things");
            mnuThings.MenuItems.Add(new MenuItem("&Remove", 
                new EventHandler(mnuThingRemove_Click),
                Shortcut.CtrlR));
            mnuThings.MenuItems.Add(new MenuItem("&Move", 
                new EventHandler(mnuThingMove_Click),
                Shortcut.CtrlM));
            mnuThings.MenuItems.Add(new MenuItem("&Put Block",
                new EventHandler(mnuPutBlock_Click),
                Shortcut.CtrlB));
            mnuThings.MenuItems.Add("-");            

            MainMenu mnu = new MainMenu(new MenuItem[] { mnuFile, mnuWorlds, mnuThings });

            Menu = mnu;
            Name = "Ucu Life";
            Text = "Ucu Life";

            executor = new GuiExecutor(this, 100);
        }

        #region IExecutor implementation

        public void AddAction(IAction action)
        {
            executor.AddAction(action);
        }

        public Boolean ContainsAction(IAction action)
        {
            return executor.ContainsAction(action);
        }

        #endregion

        #region IMainGui implementation

        /// <summary>
        /// Inicia la aplicacion, muestra la ventana e inicia el ejecutor de acciones.
        /// </summary>
        public void Run()
        {
            executor.Start();
            Application.Run(this);
        }

        public void AddListener<T>(T listener) where T : IListener
        {
            Debug.Assert(listener != null, "listener must not be null");

            IList<IListener> listenersForT;
            if (!listeners.ContainsKey(typeof(T)))
            {
                listenersForT = new List<IListener>();
                listeners[typeof(T)] = listenersForT;
            }
            else
            {
                listenersForT = listeners[typeof(T)];
            }
            listenersForT.Add(listener);                        
        }

        public Boolean ContainsListener<T>(T listener) where T : IListener
        {
            Debug.Assert(listener != null, "listener must not be null");

            return GetListeners<T>().Contains(listener);
        }

        public void AddGuiListener(IGuiListener listener)
        {
            Debug.Assert(listener != null, "listener must not be null");

            AddListener<IWorldSelectedListener>(listener);
            AddListener<IThingSelectedListener>(listener);
            AddListener<ICellSelectedListener>(listener);

            Debug.Assert(ContainsGuiListener(listener));            
        }
        
        public Boolean ContainsGuiListener(IGuiListener listener)
        {
            Debug.Assert(listener != null, "listener must not be null");

            return ContainsListener<IWorldSelectedListener>(listener) &&
                ContainsListener<IThingSelectedListener>(listener) &&
                ContainsListener<ICellSelectedListener>(listener);
        }

        public void AddWorld(String worldName)
        {
            Debug.Assert(worldName != null && worldName.Length > 0);
            Debug.Assert(!ContainsWorld(worldName));
            Int32 oc = worlds.Count;
                        

            MenuItem item = new MenuItem();
            item.Text = worldName;
            item.Click += new System.EventHandler(this.mnuWorld_Click);
                        
            worldsByMenu[item] = worldName;
            worlds.Add(worldName);
            mnuWorlds.MenuItems.Add(item);


            Debug.Assert(ContainsWorld(worldName));
            Debug.Assert(worlds.Count == oc + 1);
        }

        public Boolean ContainsWorld(String worldName)
        {
            Debug.Assert(worldName != null && worldName.Length > 0);

            return worlds.Contains(worldName);
        }

        public void AddThing(String thingName)
        {
            Debug.Assert(thingName != null && thingName.Length > 0);
            Debug.Assert(!ContainsWorld(thingName));
            Int32 oc = things.Count;

            MenuItem item = new MenuItem();
            item.Text = thingName;
            item.Click += new System.EventHandler(this.mnuThing_Click);

            thingsByMenu[item] = thingName;
            things.Add(thingName);
            mnuThings.MenuItems.Add(item);

            Debug.Assert(ContainsThing(thingName));
            Debug.Assert(things.Count == oc + 1);
        }

        public Boolean ContainsThing(String thingName)
        {
            Debug.Assert(thingName != null && thingName.Length > 0);

            return things.Contains(thingName);
        }

        #endregion

        #region Menu event handlers

        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuPlayPause_Click(object sender, System.EventArgs e)
        {
            NotifyListeners(
                    GetListeners<IPlayPauseListener>(),
                    delegate(IPlayPauseListener listener)
                    {
                        listener.PlayPauseClicked();
                    }
                    );            
        }

        private void mnuWorld_Click(object sender, System.EventArgs e)
        {
            String worldName = (String) worldsByMenu[((MenuItem)sender)];

            NotifyListeners(
                    GetListeners<IWorldSelectedListener>(),
                    delegate(IWorldSelectedListener listener)
                    {
                       listener.WorldSelected(worldName);
                    }
                    );            
        }

        private void mnuThing_Click(object sender, System.EventArgs e)
        {
            String thingName = (String)thingsByMenu[((MenuItem)sender)];

            NotifyListeners(
                    GetListeners<IThingSelectedListener>(),
                    delegate(IThingSelectedListener listener)
                    {
                        listener.ThingSelected(thingName);
                    }
                    );                       
        }

        private void mnuThingRemove_Click(object sender, System.EventArgs e)
        {
            NotifyListeners(
                    GetListeners<IRemoveListener>(),
                    delegate(IRemoveListener listener)
                    {
                       listener.RemoveClicked();
                    }
                    );
        }

        private void mnuThingMove_Click(object sender, System.EventArgs e)
        {            
            NotifyListeners(
                   GetListeners<IMoveListener>(),
                   delegate(IMoveListener listener)
                   {
                       listener.MoveClicked();
                   }
                   );
        }
        
        private void mnuPutBlock_Click(object sender, System.EventArgs e)
        {
            NotifyListeners(
                    GetListeners<IBlockSelectedListener>(),
                    delegate(IBlockSelectedListener listener)
                    {
                        listener.BlockSelected();
                    }
                    );
        }

        private void MainGui_MouseClick(object sender, MouseEventArgs e)
        {
            if (LastBoard != null)
            {
                IPoint cell = new Point(e.X / XPixelSize, e.Y / YPixelSize);
                if (cell.X < BoardWidth && cell.Y < BoardHeight)
                {
                    NotifyListeners(
                        GetListeners<ICellSelectedListener>(),
                        delegate(ICellSelectedListener listener)
                        {
                            listener.CellSelected(cell);
                        }
                        );            
                }
            }            
        }

        private void MainGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            executor.Stop();
        }

        #endregion

        private IList<T> GetListeners<T>() where T : IListener
        {
            /* muy poco performante para codigo real, sirve para evitar
             * agregar mucho codigo cuando se agrega un nuevo listener.
             * En codigo real se usarian delegates, o colecciones 
             * independientes para cada tipo de listener.
             */
            IList<T> listenersForT;   
            if (!listeners.ContainsKey(typeof(T)))
            {
                listenersForT = new List<T>();                                
            }
            else
            {
                listenersForT = new List<T>();
                foreach (IListener listener in listeners[typeof(T)])
                {
                    listenersForT.Add((T)listener);
                }
            }
            return listenersForT;
        }

        private void NotifyListeners<T>(IList<T> listeners, Notification<T> notification)
        {            
            foreach (T listener in listeners)
            {
                notification(listener);                                
            }
        }        
    }
}