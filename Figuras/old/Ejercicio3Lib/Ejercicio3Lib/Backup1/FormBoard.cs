using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Drawing
{
    /// <summary>
    /// Ventana que muestra el estado de una pizzarra.
    /// </summary>
    /// <remarks>
    /// El tamaño de los pixeles usados para dibujar es determinado por el ancho y alto de la
    /// ventana y el alto y ancho de la pizzarra.
    /// </remarks>
    public sealed partial class FormBoard : Form
    {               
        private readonly Int32 yPixelSize;

        private readonly Int32 xPixelSize;

        private readonly IBoard model;        
       
        /// <summary>
        /// Construye una nueva ventana que muestra la pizzarra 
        /// pasada por parámetro
        /// </summary>
        /// <param name="model">La pizzarra a mostrar.</param>
        public FormBoard(IBoard model)
        {
            Debug.Assert(model != null, "Null model");
           
            InitializeComponent();
            this.xPixelSize = this.MaximumSize.Width / model.MaxX;
            this.yPixelSize = this.MaximumSize.Height / model.MaxY;            
            this.model = model;
        }
         
        /// <summary>
        /// Retorna <code>true</code> si se han pintado nuevo puntos desde 
        /// la última llamada a éste método.
        /// </summary>
        public Boolean Changed
        {
            get
            {
                return model.Changed;
            }
        }

        private void FormBoard_Paint(object sender, PaintEventArgs e)
        {           
            Debug.Assert(sender != null, "Null sender");
            Debug.Assert(e != null, "Null event");

            Refresh(e.Graphics);
        }

        private void Refresh(Graphics graphics)
        {
            Debug.Assert(graphics != null, "Null graphics");
            Debug.Assert(model != null, "Null model");

            for (Int32 x = 0; x <= model.MaxX; x++)
            {
                for (Int32 y = 0; y <= model.MaxY; y++)
                {
                    if (model.IsPainted(x, y))
                    {                        
                        graphics.FillRectangle(
                            new SolidBrush(model.GetColor(x, y)),
                             x * xPixelSize,
                            (model.MaxY - 1 - y) * yPixelSize,
                            xPixelSize,
                            yPixelSize);
                    }
                }
            }
        }

        private void FormBoard_Load(object sender, EventArgs e)
        {
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void FormBoard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
            Application.Exit();
        }       
    }
}