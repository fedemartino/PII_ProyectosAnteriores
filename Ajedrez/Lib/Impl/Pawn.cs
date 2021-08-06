using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lib.Impl
{
    class Pawn : IShapedPiece
    {
        public enum Direction
        {
            Up = 1,
            Down = -1
        }
        bool firstMove = true;
        Coordenada currentPosition;
        Direction direction;
        
        public Pawn(Coordenada initialPos, Direction direction)
        {
            this.direction = direction;
            this.currentPosition = initialPos;
        }
        public bool IsValidMove(Coordenada newPos, IBoard board)
        {
            List<Coordenada> validMoves = this.ValidMoves(board);
            bool validMove = false;
            foreach (Coordenada c in validMoves)
            {
                if ((c.X == newPos.X) && (c.Y == newPos.Y))
                {
                    validMove = true;
                }
            }
            return validMove;
        }

        public List<Coordenada> ValidMoves(IBoard board)
        {
            List<Coordenada> validMoves = new List<Coordenada>();
            Coordenada newCoordenada;

            //un lugar adelante
            newCoordenada = new Coordenada(this.currentPosition.X, this.currentPosition.Y + 1 * Convert.ToInt32((this.direction)));
            if ((board.Height <= newCoordenada.Y) && (board.Width <= newCoordenada.X) && (!board.GetCell(newCoordenada.X, newCoordenada.Y).HasPiece()))
            {
                validMoves.Add(newCoordenada);
            }
            return validMoves;
        }

        public System.Drawing.Drawing2D.GraphicsPath GetShape()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(new Point(50,10), new Point(90,90));
            path.AddLine(new Point(90,90), new Point(10,90));
            path.CloseFigure();
            return path;
        }

        public Color GetShapeColor()
        {
            return new Color(0,0,255);
        }

        public void Move(Coordenada newPos)
        {
 
        }

    }
}
