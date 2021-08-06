using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PicfilLib
{
    /// <summary>
    /// Una implementacion de la interfaz de usuario para la aplicacion de filtrado de imagenes.
    /// </summary>
    public partial class PicfilGui : FormBoard, IPicfilGui
    {
        private readonly MenuItem mnuFilters;

        private readonly IDictionary<MenuItem, String> filtersByMenu = new Dictionary<MenuItem, String>();

        private readonly IList<String> filters = new List<String>();
        
        private readonly IList<IGuiListener> guiListeners = new List<IGuiListener>();        
        private readonly IList<IMacroListener> macroListeners = new List<IMacroListener>();
        private readonly IList<IFilterPersistListener> filterPersistListeners = new List<IFilterPersistListener>();
        private readonly IList<IPicturePersistListener> picturePersistListeners = new List<IPicturePersistListener>();
                         
        private readonly IPictureRenderer renderer;        

        /// <summary>
        /// Construye una nueva interfaz
        /// </summary>
        /// <param name="width">el ancho de la ventana principal de la interfaz</param>
        /// <param name="height">el alto de la ventana principal de la interfaz</param>
        public PicfilGui(Int32 width, Int32 height)
            :base(width, height)
        {                 
            InitializeComponent();

            renderer = new PictureFormRenderer(this, this);

            MenuItem mnuFileOpen = new MenuItem("&Open", new EventHandler(mnuFileOpen_Click));
            MenuItem mnuFileSave = new MenuItem("&Save", new EventHandler(mnuFileSave_Click));
            MenuItem mnuFileExit = new MenuItem("E&xit", new EventHandler(mnuFileExit_Click));
            MenuItem mnuFile = new MenuItem("&File");
            mnuFile.MenuItems.Add(mnuFileOpen);
            mnuFile.MenuItems.Add(mnuFileSave);
            mnuFile.MenuItems.Add("-");
            mnuFile.MenuItems.Add(mnuFileExit);                

            MenuItem mnuSaveFilters = new MenuItem("Save Filters", new EventHandler(mnuFiltersSave_Click));
            mnuFilters = new MenuItem("Fi&lters", new MenuItem[] { mnuSaveFilters });
            mnuFilters.MenuItems.Add("-");

            MenuItem mnuMacroRecord = new MenuItem("&Record", new EventHandler(mnuMacroRecord_Click));
            MenuItem mnuMacroStop = new MenuItem("S&top Recording", new EventHandler(mnuMacroStop_Click));
            MenuItem mnuMacros = new MenuItem("&Macros", 
                new MenuItem[] { mnuMacroRecord, mnuMacroStop });

            MainMenu mnu = new MainMenu(new MenuItem[] 
                    { mnuFile, mnuFilters, mnuMacros });

            Menu = mnu;
            Name = "PicFil GUI";
            Text = "PicFil GUI";
        }

        #region IPictureRenderer Members

        /// <summary>
        /// Despliega la imagen.
        /// </summary>
        /// <param name="picture">La imagen</param>
        public void Render(IPicture picture)
        {
            Debug.Assert(picture != null);

            renderer.Render(picture);
        }

        #endregion
        
        #region IPicfilGui Members

        /// <summary>
        /// Agrega un nuevo filtro a la interfaz para que pueda ser seleccionado por el usuario.
        /// </summary>
        /// <remarks>
        /// <para>
        /// No puede agregarse dos veces el mismo nombre de filtro a la interfaz.
        /// </para>
        /// <para>
        /// La forma en la cual se despliega el filtro es dependiente de la implementacion.
        /// </para>
        /// </remarks>
        /// <param name="filterName">el nombre del filtro a agregar</param>
        public void AddFilter(string filterName)
        {
            Debug.Assert(filterName != null);
            Debug.Assert(!filters.Contains(filterName));

            MenuItem item = new MenuItem();
            item.Text = filterName;
            item.Click += new System.EventHandler(this.mnuFilter_Click);
            filtersByMenu[item] = filterName;
            filters.Add(filterName);
            mnuFilters.MenuItems.Add(item);

            Debug.Assert(ContainsFilter(filterName));            
        }

        /// <summary>
        /// Retorna si ya existe un filtro con ese nombre en la interfaz.        
        /// </summary>
        /// <param name="filterName">el nombre del filtro</param>
        /// <returns><code>true</code>si ya existe <code>false</code> en otro caso.</returns>
        public Boolean ContainsFilter(string filterName)
        {
            Debug.Assert(filterName != null);

            return filters.Contains(filterName);
        }

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de aplicacion
        /// de filtros o de seleccion de imagenes.
        /// </summary>
        /// <param name="listener">el observador</param> 
        public void AddListener(IGuiListener listener)
        {
            Debug.Assert(listener != null);

            guiListeners.Add(listener);

            Debug.Assert(ContainsListener(listener));
        }

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        public Boolean ContainsListener(IGuiListener listener)
        {
            Debug.Assert(listener != null);

            return guiListeners.Contains(listener);
        }

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de macros.
        /// </summary>
        /// <param name="listener">el observador</param>        
        public void AddMacroListener(IMacroListener listener)
        {
            Debug.Assert(listener != null);

            macroListeners.Add(listener);

            Debug.Assert(ContainsMacroListener(listener));
        }

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        public Boolean ContainsMacroListener(IMacroListener listener)
        {
            Debug.Assert(listener != null);

            return macroListeners.Contains(listener);
        }

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de persistencia
        /// de filtros.
        /// </summary>
        /// <param name="listener">el observador</param>        
        public void AddFilterPersistListener(IFilterPersistListener listener)
        {
            Debug.Assert(listener != null);

            filterPersistListeners.Add(listener);

            Debug.Assert(ContainsFilterPersistListener(listener));
        }

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        public Boolean ContainsFilterPersistListener(IFilterPersistListener listener)
        {
            Debug.Assert(listener != null);

            return filterPersistListeners.Contains(listener);
        }

        /// <summary>
        /// Registra un observador con la interfaz para recibir eventos de persistencia
        /// de imagenes.
        /// </summary>
        /// <param name="listener">el observador</param>        
        public void AddPicturePersistListener(IPicturePersistListener listener)
        {
            Debug.Assert(listener != null);

            picturePersistListeners.Add(listener);

            Debug.Assert(ContainsPicturePersistListener(listener));
        }

        /// <summary>
        /// Retorna si el observador pasado por argumento esta registrado con 
        /// esta interfaz.
        /// </summary>
        /// <param name="listener">el observador</param>
        /// <returns><code>true</code>si esta registrado, <code>false</code> en otro caso.</returns>
        public Boolean ContainsPicturePersistListener(IPicturePersistListener listener)
        {
            Debug.Assert(listener != null);

            return picturePersistListeners.Contains(listener);
        }

        /// <summary>
        /// Inicia y ejecuta la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Este metodo debe utilizar en lugar de <code>Application.Run()</code>
        /// </remarks>
        public void Run()
        {
            Application.Run(this);
        }

        #endregion

        #region Menu event handlers

        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileOpen_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                NotifySelectPicture(dlgOpen.FileName);                                
            }
        }

        private void mnuFileSave_Click(object sender, System.EventArgs e)
        {            
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Title = "Save image";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {                
                NotifyFileSave(dlgSave.FileName);
            }
        }

        private void mnuFilter_Click(object sender, System.EventArgs e)
        {            
            String filterName = filtersByMenu[((MenuItem)sender)];

            NotifyFilter(filterName);            
        }

        private void mnuFiltersSave_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Title = "Save filters";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {                
                NotifyPersistFilters(dlgSave.FileName);
            }
        }

        private void mnuMacroRecord_Click(object sender, System.EventArgs e)
        {
            RecordMacroDialog dialog = new RecordMacroDialog();
            dialog.ShowDialog(this);
            String macroName = dialog.MacroName;

            if (macroName != null && !macroName.Trim().Equals(""))
            {                
                NotifyRecordMacro(macroName);
            }
        }

        private void mnuMacroStop_Click(object sender, System.EventArgs e)
        {            
            NotifyStopRecordMacro();
        }

        #endregion

        #region Listener notifiers

        private void NotifyFilter(String filterName)
        {
            foreach (IGuiListener listener in guiListeners)
            {
                listener.ApplyFilter(filterName);
            }
        }

        private void NotifyPersistFilters(String filtersFileName)
        {
            foreach (IFilterPersistListener listener in filterPersistListeners)
            {
                listener.PersistFilters(filtersFileName);
            }
        }

        private void NotifyRecordMacro(String macroName)
        {
            foreach (IMacroListener listener in macroListeners)
            {
                listener.RecordMacro(macroName);
            }
        }
        
        private void NotifyStopRecordMacro()
        {
            foreach (IMacroListener listener in macroListeners)
            {
                listener.StopRecordMacro();
            }
        }

        private void NotifyFileSave(String fileName)
        {            
            foreach (IPicturePersistListener listener in picturePersistListeners)
            {
                listener.PersistPicture(fileName);
            }
        }

        private void NotifySelectPicture(String pictureName)
        {
            try
            {
                foreach (IGuiListener listener in guiListeners)
                {
                    listener.SelectPicture(pictureName);
                }
            }
            catch (ArgumentException e)
            {
                System.Windows.Forms.MessageBox.Show("La imagen '" + pictureName + "' no es valida: " + e.Message);
            }
        }
        
        #endregion

    }    
}