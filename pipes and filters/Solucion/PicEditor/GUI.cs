using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicfilLib;
using System.IO;
using System.Reflection;
using PicEditor.Filtros;

namespace PicEditor
{
    public partial class GUI : Form
    {
        #region Definición de objetos y variables
        //Creo los objetos necesario para leer y mostrar la imagen
        IPictureProvider provider;
        IPictureRenderer renderer;

        //Creo las tres imagenes que voy a utilizar para pruebas
        IPicture picture;

        //Creo los strings con los path de cada imagen
        const String fileMyagi = "sr.jpg";
        const String filePrueba = "TestImage.bmp";
        const String filePrueba2 = "PruebaColores.gif";
        const String fileMario = "Mario.gif";
        String defaultPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Recursos");
        String path;

        //Creo un filtro que voy a reutilizar
        IFilter filtro;

        FilterBW filtroBW;
        FilterNegative filtroNeg;
        FilterGreyscale filtroGrey;
        #endregion

        public GUI()
        {
            provider = new PictureProvider();
            renderer = new PictureFormRenderer();
            picture = new Picture(1, 1);

            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            provider.ReadIntoImage(path, picture);
            if (tabFiltros.SelectedTab == tabFiltros.TabPages[0])
            {
                aplicarFiltros();
            }
            else
            {
                aplicarSecuenciaFiltros();
            }
            renderer.Render(picture);
        }

        private void cmbImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtImagen.Enabled = false;
            btnLoadImage.Enabled = false;
            switch (cmbImagen.SelectedItem.ToString())
            {
                case "Mario Bros.":
                    path = Path.Combine(defaultPath, fileMario);
                    break;
                case "Sr. Myagi":
                    path = Path.Combine(defaultPath, fileMyagi);
                    break;
                case "Imagen prueba 1":
                    path = Path.Combine(defaultPath, filePrueba);
                    break;
                case "Imagen prueba 2":
                    path = Path.Combine(defaultPath, filePrueba2);
                    break;
                default:
                    btnLoadImage.Enabled = true;
                    break;
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            imageFileDialog.ShowDialog();
            txtImagen.Text = imageFileDialog.FileName;
            path = Path.GetFullPath(txtImagen.Text);
        }
        private void cmbFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltros.SelectedItem.ToString() == "Tags")
            {
                btnLoadTags.Enabled = true;
                if (txtTags.Text == "")
                {
                    btnLoadTags_Click(sender, e);
                }
            }
            else 
            {
                btnLoadTags.Enabled = false;
            }
        }

        private void btnLoadTags_Click(object sender, EventArgs e)
        {
            tagFileDialog.ShowDialog();
            txtTags.Text = tagFileDialog.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFiltros.SelectedItem = "Ninguno";
            cmbImagen.SelectedIndex = 0;
            
            filtroBW = new FilterBW(190);
            filtroGrey = new FilterGreyscale();
            filtroNeg = new FilterNegative();

            lstViewFiltros.Items.Add("Negativo");
            lstViewFiltros.Items[0].Tag = filtroNeg;
            lstViewFiltros.Items.Add("Blanco & Negro");
            lstViewFiltros.Items[1].Tag = filtroBW;
            lstViewFiltros.Items.Add("Grises");
            lstViewFiltros.Items[2].Tag = filtroGrey;
        }

        private void aplicarFiltros()
        {
            switch (cmbFiltros.SelectedItem.ToString())
            {
                case "Ninguno":
                    filtro = null;
                    break;
                case "Negativo":
                    filtro = new FilterNegative();
                    break;
                case "Blanco & Negro":
                    filtro = new FilterBW(190);
                    break;
                case "Grises":
                    filtro = new FilterGreyscale();
                    break;
                case "Suavizar":
                    filtro = new FilterBlur();
                    break;
                case "Relieve":
                    filtro = new FilterEmboss();
                    break;
                case "Tags":
                    if (txtTags.Text == "")
                    {
                        btnLoadTags_Click(null, null);
                    }
                    filtro = new FilterTag(Path.GetFullPath(txtTags.Text));
                    break;
            }
            if (filtro != null)
            {
                try
                {
                    picture = filtro.Filter(picture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    filtro = null;
                }
            }
        }

        public void aplicarSecuenciaFiltros()
        {
            foreach (ListViewItem i in lstViewSecuenciaFiltros.Items)
            {
                picture = ((IFilter)i.Tag).Filter(picture);
            }
 
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            ListViewItem i = new ListViewItem(lstViewFiltros.SelectedItems[0].Text);
            i.Tag = lstViewFiltros.SelectedItems[0].Tag;
            lstViewSecuenciaFiltros.Items.Add(i);
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            lstViewSecuenciaFiltros.Items.Remove(lstViewSecuenciaFiltros.SelectedItems[0]);
        }
    }
}
