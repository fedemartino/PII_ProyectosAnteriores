using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace PicfilLib
{
    /// <summary>
    /// Despliega imagenes en un formulario nuevo o en uno existente.
    /// </summary>
    public class PictureFormRenderer : IPictureRenderer
    {
        private readonly Form main;
        private readonly FormBoard destination;
        private readonly PictureTransformer transformer = new PictureTransformer();

        /// <summary>
        /// Crea una nueva instancia que despliega imagenes sobre un nuevo formulario.        
        /// </summary>
        /// <remarks>
        /// Para usar este metodo es fundamental que el bucle de eventos de la aplicacion
        /// no se haya iniciado. Esto significa, que no se haya llamado a Application.Run() 
        /// o similar.
        /// </remarks>
        public PictureFormRenderer()
        {
            this.main = null;
        }

        /// <summary>
        /// Crea una nueva instancia que despliega imagenes sobre un nuevo formulario.
        /// </summary>
        /// <param name="main">la ventana principal de la aplicacion</param>
        public PictureFormRenderer(Form main)
        {
            Debug.Assert(main != null, "El formulario principal no debe ser nulo");
            
            this.main = main;
        }

        /// <summary>
        /// Crea una nueva instancia que despliega imagenes sobre el formulario de destinto
        /// pasado como argumento.
        /// </summary>
        /// <param name="main">la ventana principal de la aplicacion</param>
        /// <param name="destination">el formulario de destino</param>
        public PictureFormRenderer(Form main, FormBoard destination)
        {
            Debug.Assert(main != null, "El formulario principal no debe ser nulo");
            Debug.Assert(destination != null, "El formulario de destino no debe ser nulo");

            this.main = main;
            this.destination = destination;
        }

        /// <summary>
        /// Despliega la imagen.
        /// </summary>
        /// <param name="picture">la imagen a desplegar</param>
        public void Render(IPicture picture)
        {
            Debug.Assert(picture != null, "La imagen a desplegar no debe ser nulo");
            
            RunRenderer(new Renderer(GetBitmap(picture), destination));
        }

        #region IPictureExtendedRenderer Members

        public void Render(IPicture picture, Int32 x, Int32 y)
        {
            Debug.Assert(picture != null, "La imagen a desplegar no debe ser nulo");
            
            RunRenderer(new Renderer(new Point(x, y), GetBitmap(picture), destination));            
        }

        #endregion

        private void RunRenderer(Renderer renderer)
        {
            Debug.Assert(renderer != null);
            
            if (main != null && main.InvokeRequired)
            {
                this.main.Invoke(new RenderPictureDelegate(renderer.RenderPicture));
            }
            else
            {
                renderer.RenderPicture();
            }
        }

        private Bitmap GetBitmap(IPicture picture)
        {
            return transformer.GetBitmap(picture);
        }
       
        public delegate void RenderPictureDelegate();

        public class Renderer
        {
            private readonly Point origin;            
            private readonly Bitmap bitmap;
            private readonly FormBoard destination;

            public Renderer(Point origin, Bitmap bitmap, FormBoard destination)
            {
                this.origin = origin;
                this.bitmap = bitmap;
                this.destination = destination;
            }

            public Renderer(Bitmap bitmap, FormBoard destination)
                : this(new Point(0,0), bitmap, destination)
            {                
            }

            public void RenderPicture()
            {
                FormBoard board = (destination == null 
                    ? new FormBoard(bitmap.Width, bitmap.Height) : destination);
                
                Graphics g = Graphics.FromImage(board.Bitmap);
                g.Clear(board.BackColor);
                g.DrawImage(bitmap, origin);
                board.Redraw();
                
                board.Show();                
            }
        }        
    }
}