using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Imaging;
using System.Threading;

namespace PainterLib
{
    /// <summary>
    /// Ventana que muestra el estado de una pizzarra.
    /// </summary>
    /// <remarks>
    /// El tamaño de los pixeles usados para dibujar es determinado por el ancho y alto de la
    /// ventana y el alto y ancho de la pizzarra. Es decir, si la ventana es de 800x800 y la pizarra
    /// de 400x400, se asumira que cada punto de la pizarra en realidad ocupa 2x2 pixeles.
    /// </remarks>
    public sealed partial class FormBoard : Form, IGui
    {         
        // a bitmap to draw the board to      
        private Bitmap bitmap;
        
        /// <summary>
        /// Construye una nueva ventana que muestra la pizzarra 
        /// pasada por parámetro
        /// </summary>
        /// <param name="model">La pizzarra a mostrar.</param>
        public FormBoard(Int32 width, Int32 height)
        {            
            this.Width = Math.Max(800, width + 20);
            this.Height = Math.Max(600, height + 20);
            
            InitializeComponent();                       
        }

        /// <summary>
        /// Abre y muestra el control grafico.
        /// </summary>
        /// <remarks>
        /// Este metodo debe invocarse para que sea posible ver el componente por
        /// pantalla. En otro caso, no se vera nada.
        /// </remarks>
        public void Open()
        {
            Show();
        }

        /// <summary>
        /// Dibuja la pizarra en pantalla.
        /// </summary>
        /// <param name="board">La pizarra.</param>
        public void Redraw(IBoard board)
        {
            lock (this)
            {
                this.bitmap = GetBitmap(board);
            }
            
            try
            {
                Invoke(new ExecuteActionDelegate(RedrawBitmap));
            }
            catch (ThreadInterruptedException)
            {
            }
        }

        // delegate to draw the bitmap on the UI thread.
        private delegate void ExecuteActionDelegate();
        private void RedrawBitmap()
        {
            Invalidate();
            Update();
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
            
            lock (this)
            {
                if (bitmap != null)
                {
                    graphics.DrawImage(bitmap, new System.Drawing.Point(0, 0));
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
        
        public Bitmap GetBitmap(IBoard board)
        {
            Debug.Assert(board != null);

            Bitmap bitmap = new Bitmap(Width-10, Height-10);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0,
                    bitmap.Width, bitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);
            
            Int32 bitsPerPixel = 4;
            Int32 offset = bitmapData.Stride - (bitmapData.Width * bitsPerPixel);
            Int32 xPixelSize = this.MaximumSize.Width / board.MaxX;
            Int32 yPixelSize = this.MaximumSize.Height / board.MaxY;            
            unsafe
            {                
                    byte* imagePointer1 = (byte*)bitmapData.Scan0;
                    Int32 boardY = 0;
                    for (int y = 0; y < bitmapData.Height; y++)
                    {
                        boardY = y / yPixelSize;
                        Int32 boardX = 0;
                        for (int x = 0; x < bitmapData.Width; x++)
                        {
                            boardX = x / xPixelSize;
                            lock (board)
                            {
                                if (board.IsPainted(boardX, boardY))
                                {                                    
                                    Int32 color = board.GetColor(boardX, boardY).ToArgb();
                                    imagePointer1[0] = (byte)(color & 0xFF);
                                    imagePointer1[1] = (byte)((color >> 8) & 0xFF);
                                    imagePointer1[2] = (byte)((color >> 16) & 0xFF);
                                    imagePointer1[3] = (byte)((color >> 24) & 0xFF);
                                }
                                else
                                {
                                    imagePointer1[0] = 0;
                                    imagePointer1[1] = 0;
                                    imagePointer1[2] = 0;
                                    imagePointer1[3] = 0xFF;
                                }
                            }
                            imagePointer1 += bitsPerPixel;
                        }
                        imagePointer1 += offset;
                    }                
            }
            bitmap.UnlockBits(bitmapData);

            Debug.Assert(bitmap != null);

            return bitmap;
        }
    }
    
}