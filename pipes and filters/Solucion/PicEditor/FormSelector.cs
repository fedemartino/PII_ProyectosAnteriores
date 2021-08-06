using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicEditor.Filtros;
using System.IO;
using System.Reflection;
using System.Collections;


namespace PicEditor
{
    public partial class FormSelector : Form
    {
        string archivoTags = "";
        public FormSelector()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                archivoTags = openFileDialog1.FileName;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            String defaultPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Recursos");
            PicfilLib.PicfilGui f = new PicfilLib.PicfilGui(400, 200);

            //Cargo los tags y creo los filtros correspondientes
            FileReader reader = new FileReader();
            string tagFile = "pruebaTags.txt";
            if (archivoTags != "")
            {
                tagFile = archivoTags;
            }
            reader.LeerArchivo(Path.Combine(defaultPath, tagFile));
            Hashtable a = reader.InterpretarTags();
            
            foreach (DictionaryEntry entry in a)
            {
                if (entry.Value is PicfilLib.IFilter)
                {
                    PicfilLib.IFilter filtro = (PicfilLib.IFilter)entry.Value;
                    f.AddFilter(filtro.Name);
                }
            }
            //Creo todos los listeners
            HashListener guiListener = new PicEditor.HashListener(f, a);
            Macros.MacroBuilderListener macroBuilder = new Macros.MacroBuilderListener(a, f);
            Persistencia.FilterPersister filterPersister = new Persistencia.FilterPersister(a, Persistencia.TagDatabase.ObjectToTag());
            
            //agrago los listeners
            f.AddListener(guiListener);
            f.AddListener(macroBuilder);
            f.AddMacroListener(macroBuilder);
            f.AddFilterPersistListener(filterPersister);
            f.AddPicturePersistListener(guiListener);

            //Muestro la interfaz gráfica
            this.Hide();
            f.IsMdiContainer = true;
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
            this.Close();

        }
        private void FormSelector_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnLoad, "Lee los datos del archivo seleccionado \ry los carga en la interfaz gráfica.\rSi no se selecciona ningún archivo, carga uno por defecto");
        }
        
    }
}
;