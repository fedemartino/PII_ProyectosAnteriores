using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PainterLib;

namespace UcuLifeLib
{
    /// <summary>
    /// La interfaz principal de UcuLife.
    /// </summary>
    public sealed partial class MainGui : FormBoard, IMainGui
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

        private readonly ArrayList guiListeners = new ArrayList();

        private readonly ArrayList worlds = new ArrayList();

        private readonly Hashtable worldsByMenu = new Hashtable();

        private readonly ArrayList things = new ArrayList();

        private readonly Hashtable thingsByMenu = new Hashtable();

        private readonly MenuItem mnuWorlds;

        private readonly MenuItem mnuThings;



        public MainGui(Int32 width, Int32 height)
            : base(width, height)
        {
            InitializeComponent();

            MenuItem mnuFileExit = new MenuItem("E&xit", new EventHandler(mnuFileExit_Click));
            MenuItem mnuFile = new MenuItem("&File");
            mnuFile.MenuItems.Add(mnuFileExit);

            mnuWorlds = new MenuItem("&Worlds");
            mnuWorlds.MenuItems.Add("-");

            mnuThings = new MenuItem("&Things");
            mnuThings.MenuItems.Add("-");

            MainMenu mnu = new MainMenu(new MenuItem[] { mnuFile, mnuWorlds, mnuThings });

            Menu = mnu;
            Name = "Ucu Life";
            Text = "Ucu Life";
        }        

        public void Run()
        {
            Application.Run(this);
        }

        public void AddGuiListener(IGuiListener listener)
        {
            Debug.Assert(listener != null);
            Int32 oc = guiListeners.Count;

            guiListeners.Add(listener);

            Debug.Assert(guiListeners.Contains(listener));
            Debug.Assert(guiListeners.Count == oc + 1);
        }
        
        public Boolean ContainsGuiListener(IGuiListener listener)
        {
            Debug.Assert(listener != null);

            return guiListeners.Contains(listener);
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

        #region Menu event handlers

        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuWorld_Click(object sender, System.EventArgs e)
        {
            String worldName = (String) worldsByMenu[((MenuItem)sender)];

            NotifyShowWorld(worldName);
        }

        private void mnuThing_Click(object sender, System.EventArgs e)
        {
            String thingName = (String)thingsByMenu[((MenuItem)sender)];

            NotifyThingSelected(thingName);
        }

        private void MainGui_MouseClick(object sender, MouseEventArgs e)
        {
            lock (this)
            {
                if (LastBoard != null)
                {
                    IPoint cell = new Point(e.X / XPixelSize, e.Y / YPixelSize);
                    if (cell.X < BoardWidth && cell.Y < BoardHeight)
                    {
                        NotifyCellSelected(cell);
                    }
                }
            }
        }

        #endregion

        #region Listener notifiers

        private void NotifyShowWorld(String worldName)
        {
            foreach (IGuiListener listener in guiListeners)
            {
                listener.WorldSelected(worldName);
            }
        }

        private void NotifyThingSelected(String thingName)
        {
            foreach (IGuiListener listener in guiListeners)
            {
                listener.ThingSelected(thingName);
            }
        }

        private void NotifyCellSelected(IPoint cell)
        {
            Debug.Assert(cell != null);

            foreach (IGuiListener listener in guiListeners)
            {
                listener.CellSelected(cell);
            }
        }

        #endregion
    }
}