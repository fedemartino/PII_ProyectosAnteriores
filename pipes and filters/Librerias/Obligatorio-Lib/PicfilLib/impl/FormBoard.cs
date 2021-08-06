using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace PicfilLib
{
    /// <summary>
    /// Un formulario para uso interno de la libreria que al dibujarse muestra el contenido
    /// de una imagen.
    /// </summary>
    public partial class FormBoard : Form
    {
        private Bitmap bitmap;

        /// <summary>
        /// Obtiene la imagen que muestra el formulario.
        /// </summary>
        public Bitmap Bitmap { get { return bitmap; } }

        public FormBoard(Int32 width = 200, Int32 height = 200)
        {
            Debug.Assert(width >= 0, "El ancho del formulario debe ser mayor o igual a cero");
            Debug.Assert(height >= 0, "El alto del formulario debe ser mayor o igual a cero");

            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.bitmap = new Bitmap(width, height);
        }

        public void Redraw()
        {
            this.Invalidate();
        }
        
        private void FormBoard_Paint(object sender, PaintEventArgs e)
        {            
            e.Graphics.Clear(BackColor);            
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
        }
        
        private void FormBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            bitmap.Dispose();
        }
    }
}