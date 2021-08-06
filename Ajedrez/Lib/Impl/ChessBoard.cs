using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Impl
{
    class ChessBoard : IBoard
    {
        ICell[,] cells;
        int width;
        int height;
        public ChessBoard(int width, int height)
        {
            this.height = height;
            this.width = width;
            Color color;
            this.cells = new ICell[width,height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (IsEven(i + j))
                    {
                        color = new Color(255, 255, 255);
                    }
                    else
                    {
                        color = new Color(0, 0, 0);
                    }
                    this.cells[i, j] = new Cell(color);
                    if ((j == 2) && (i == 3))
                    {
                        this.cells[i, j].AddPiece(new Pawn(new Coordenada(i, j), Pawn.Direction.Down));
                    }
                    
                }
            }
        }
        public int Width
        {
            get { return this.width; }
        }
        public int Height
        {
            get { return this.height; }
        }
        public ICell[,] GetCeldas()
        {
            return this.cells;
        }

        private Boolean IsEven(int number)
        {
            return ((number % 2) == 0);
        }
        public ICell GetCell(int x, int y)
        {
            return this.cells[x, y];
        }
    }
}
