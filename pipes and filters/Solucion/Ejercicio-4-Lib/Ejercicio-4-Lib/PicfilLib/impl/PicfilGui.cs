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
        private readonly MainMenu mnu;
        
        private readonly MenuItem mnuFile;

        private readonly MenuItem mnuFilters;
        
        private readonly MenuItem mnuFileOpen;
        
        private readonly MenuItem mnuFileExit;
        
        private readonly IDictionary<MenuItem, String> filtersByMenu = new Dictionary<MenuItem, String>();

        private readonly IList<String> filters = new List<String>();
        
        private readonly IList<IGuiListener> listeners = new List<IGuiListener>();
                         
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

            mnu = new MainMenu();
            mnuFile = new MenuItem();
            mnuFileExit = new MenuItem();
            mnuFileOpen = new MenuItem();
            mnuFilters = new MenuItem();

            mnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] 
                    { mnuFile, mnuFilters });

            mnuFile.Index = 0;
            mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] 
                    { mnuFileOpen, mnuFileExit });            
            mnuFile.Text = "&File";

            mnuFileOpen.Index = 0;
            mnuFileOpen.Text = "&Open";
            mnuFileOpen.Click += new System.EventHandler(mnuFileOpen_Click);

            mnuFileExit.Index = 1;
            mnuFileExit.Text = "E&xit";
            mnuFileExit.Click += new System.EventHandler(mnuFileExit_Click);

            mnuFilters.Index = 1;            
            mnuFilters.Text = "Fi&lters";

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
        /// Registra un observador con la interfaz para recibir eventos.
        /// </summary>
        /// <param name="listener">el observador</param> 
        public void AddListener(IGuiListener listener)
        {
            Debug.Assert(listener != null);

            listeners.Add(listener);

            Debug.Assert(listeners.Contains(listener));
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

            return listeners.Contains(listener);
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

        private void mnuFilter_Click(object sender, System.EventArgs e)
        {            
            String filterName = filtersByMenu[((MenuItem)sender)];

            NotifyFilter(filterName);            
        }

        private void NotifyFilter(String filterName)
        {
            foreach (IGuiListener listener in listeners)
            {
                listener.ApplyFilter(filterName);
            }
        }

        private void NotifySelectPicture(String pictureName)
        {
            try
            {
                foreach (IGuiListener listener in listeners)
                {
                    listener.SelectPicture(pictureName);
                }
            }
            catch (ArgumentException e)
            {
                System.Windows.Forms.MessageBox.Show("La imagen '" + pictureName + "' no es valida: " + e.Message);
            }
        }       
    }
}