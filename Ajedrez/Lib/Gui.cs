using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lib
{
    public partial class Gui : Form, IGui 
    {
        private readonly MenuItem mnuFilters;

        Bitmap bitmap;
        IBoard board;
        List<ICellSelectListener> cellSelectListeners;
        List<IMenuListener> menuListeners;

        public Gui(int width = 200, int height = 200, IBoard board = null)
        {
            InitializeComponent();
            
            //Instancio las listas de listeners
            cellSelectListeners = new List<ICellSelectListener>();
            menuListeners = new List<IMenuListener>();

            //Setea el tamaño del tablero
            this.board = board;
            this.Height = height;
            this.Width = width;
            bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            
           
            MenuItem mnuFileOpen = new MenuItem("&Open", new EventHandler(mnuFileOpen_Click));
            MenuItem mnuFileSave = new MenuItem("&Save", new EventHandler(mnuFileSave_Click));
            MenuItem mnuFileExit = new MenuItem("E&xit", new EventHandler(mnuFileExit_Click));
            MenuItem mnuFile = new MenuItem("&File");
            mnuFile.MenuItems.Add(mnuFileOpen);
            mnuFile.MenuItems.Add(mnuFileSave);
            mnuFile.MenuItems.Add("-");
            mnuFile.MenuItems.Add(mnuFileExit);

            MainMenu mnu = new MainMenu(new MenuItem[] { mnuFile});

            Menu = mnu;
        }
        #region Menu event handlers

        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileOpen_Click(object sender, System.EventArgs e)
        {
            //OpenFileDialog dlgOpen = new OpenFileDialog();
            //if (dlgOpen.ShowDialog() == DialogResult.OK)
            //{
                foreach (IMenuListener listener in this.menuListeners)
                {
                    //listener.Listen(dlgOpen.FileName);
                    listener.Listen("Open");
                }
            //}
        }

        private void mnuFileSave_Click(object sender, System.EventArgs e)
        {
            //SaveFileDialog dlgSave = new SaveFileDialog();
            //dlgSave.Title = "Save game";
            //if (dlgSave.ShowDialog() == DialogResult.OK)
            //{
                foreach (IMenuListener listener in this.menuListeners)
                {
                    //listener.Listen(dlgSave.FileName);
                    listener.Listen("Save");
                }
            //}
        }

        #endregion
        public void Draw()
        {
            this.Gui_Paint("Listener", new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
        }
        /// <summary>
        /// Obtiene el color opuesto
        /// </summary>
        /// <param name="color">Color del cual se desea obtener el opuesto</param>
        /// <returns>Color opuesto</returns>
        private System.Drawing.Color OpositeColor(Color color)
        {
            System.Drawing.Color auxColor = System.Drawing.Color.FromArgb(color.ToArgb());
            System.Drawing.Color opColor = System.Drawing.Color.FromArgb(255 - auxColor.R, 255 - auxColor.G, 255 - auxColor.B);
            return opColor;
        }
        /// <summary>
        /// Obtiene una matriz para ajustar el tamaño de la figura a el tamaño de la celda
        /// </summary>
        /// <param name="canvasW">Ancho de la celda</param>
        /// <param name="canvasH">Altura de la celda</param>
        /// <returns>Matriz de escalarización</returns>
        private System.Drawing.Drawing2D.Matrix GetScaleMatrix(int canvasW, int canvasH)
        {
            System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
            float floatX = float.Parse(canvasW.ToString()) / float.Parse("100");
            float floatY = float.Parse(canvasH.ToString()) / float.Parse("100");
            matrix.Scale(floatX, floatY);
            return matrix;
        }
        
        private void Gui_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphObj = e.Graphics;
            graphObj.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

            Rectangle rec = new Rectangle(0, 0, 40, 40);
            Pen pen;
            int borderSizeW = bitmap.Width / this.board.Width;
            int borderSizeH = bitmap.Height / this.board.Height;

            System.Drawing.Drawing2D.GraphicsPath path;
            
            for (int i = 0; i < this.board.Width; i++)
            {
                for (int j = 0; j < this.board.Height; j++)
                {
                    Color cellColor = this.board.GetCell(i, j).GetColor();
                    Brush br = new SolidBrush(System.Drawing.Color.FromArgb(cellColor.ToArgb()));
                    pen = new Pen(br);
                    rec = new Rectangle(0 + borderSizeW * i, 0 + borderSizeH * j, borderSizeW, borderSizeH);
                    graphObj.FillRectangle(br, rec);

                    System.Drawing.Drawing2D.GraphicsPath newPath;

                    if (board.GetCell(i, j).HasPiece())
                    {
                        IPiece piece = board.GetCell(i, j).GetPiece();
                        path = piece.GetShape().GetShape();
                        
                        Brush br2 = new SolidBrush(System.Drawing.Color.FromArgb(piece.GetShape().GetShapeColor().ToArgb()));
                        pen = new Pen(OpositeColor(cellColor));

                        System.Drawing.Drawing2D.Matrix matrix = GetScaleMatrix(borderSizeW, borderSizeH);
                        System.Drawing.Drawing2D.Matrix matrixMove = new System.Drawing.Drawing2D.Matrix();
                        matrixMove.Translate(borderSizeW * i, borderSizeH * j);

                        newPath = (System.Drawing.Drawing2D.GraphicsPath)path.Clone();
                        newPath.Transform(matrix);
                        newPath.Transform(matrixMove);

                        graphObj.FillPath(br2, newPath);
                        graphObj.DrawPath(pen, newPath);
                    }
                }
            }
            graphObj.Dispose();
        }

        private void Gui_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.X / (this.ClientRectangle.Width / this.board.Width);
            int j = e.Y / (this.ClientRectangle.Height / this.board.Height);
            foreach (ICellSelectListener listener in this.cellSelectListeners)
            {
                listener.Listen(new Coordenada(i, j));
            }
        }

        public void AddMenuListener(IMenuListener listener)
        {
            this.menuListeners.Add(listener);
        }

        public void AddCellSelectListener(ICellSelectListener listener)
        {
            this.cellSelectListeners.Add(listener);
        }
    }
}
