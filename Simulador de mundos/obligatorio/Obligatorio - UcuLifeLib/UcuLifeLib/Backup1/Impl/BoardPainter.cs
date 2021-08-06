using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace PainterLib
{
    /// <summary>
    /// Pinta figuras en un <see cref="IBoard"/>.
    /// </summary>    
    /// <remarks>
    /// La clase dibuja figuras dibujando líneas que unen los puntos de la figura. Por ésto
    /// es necesario que la figura retorne sus puntos en sentido horario o antihorario.
    /// <br/>
    /// Al momento de crearlo, es necesario proveer al pintor un tamanio de celda. El tamanio de celda
    /// se utiliza en el metodo <code>PaintInCell</code> para determinar el espacio a pintar.
    /// Por ejemplo, si la pizarra es de 1000x1000 y el tamanio de celda es de 100, el pintor asumira que
    /// cuando le pidan pintar desde la celda (0,0) a la (1,0) utilizando el metodo 
    /// <code>PaintInBoard</code>, en realidad tendra que pintar 100 puntos de la pizarra 
    /// (el lado de una celda). 
    /// Por otro lado, si le piden pintar un cuadrado formado por los puntos 
    /// (10,10), (90,10), (90,90), (10,90) en la celda (1,1) usando el metodo 
    /// <code>PaintInCell</code>, dibujara un cuadrado de 80x80 puntos dentro de la celda (1,1).
    /// </remarks>
    public sealed class BoardPainter: IPainter
    {       
        private readonly IBoard board;
        private readonly Int32 cellSize;

        /// Implementaciones de Point y Shape para uso interno.       
        
        private sealed class Point : IPoint
        {
            private readonly Int32 x;
            private readonly Int32 y;

            public Point(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }

            #region IPoint Members

            public int X
            {
                get { return x; }
            }

            public int Y
            {
                get { return y; }
            }

            #endregion
        }
        private sealed class Shape : IShape
        {
            private readonly IPoint[] points;

            public Shape(IPoint[] points)
            {
                this.points = points;
            }

            #region IShape Members

            public IPoint[] Points
            {
                get { return points; }
            }

            #endregion
        }

        /// <summary>
        /// Crea una nueva instancia de <code>BoardPainter</code>.
        /// </summary>
        /// <param name="board">El <code>IBoard</code> donde mostrar la figura.</param>
        public BoardPainter(IBoard board, Int32 cellSize)
        {
            Debug.Assert(board != null, "Board must not be null");

            this.board = board;
            this.cellSize = cellSize;
        }

        /// <summary>
        /// Despinta todos lo pintado por este pintor.
        /// </summary>
        public void StartOver()
        {
            board.ClearBoard();
        }

        /// <summary>
        /// Dibuja la figura en la pizarra. Los puntos de la figura seran adecuados en base al tamanio de
        /// la celda, de acuerdo a la documentacion de la clase.
        /// </summary>
        /// <param name="cell">La celda donde dibujar la figura</param>
        /// <param name="shape">La figura</param>
        /// <param name="color">El color</param>        
        public void PaintInCell(IPoint cell, IShape shape, Color color)
        {
            Paint(LocalShape(cell.X, cell.Y, shape), color);            
        }
        
        /// <summary>
        /// Dibuja la figura en la pizarra. Los puntos de la figura seran adecuados en base al tamanio de
        /// la celda, de acuerdo a la documentacion de la clase.
        /// </summary>
        /// <param name="shape">La figura</param>
        /// <param name="color">El color</param>
        public void PaintInBoard(IShape shape, Color color)
        {
            Debug.Assert(shape != null, "shape must not be null");
            Debug.Assert(color != null, "color must not be null");
            Debug.Assert(shape.Points != null, "shape point array must not be null");

            IPoint[] localPoints = new IPoint[shape.Points.Length];
            for (Int32 i = 0; i < shape.Points.Length; i++)
            {
                IPoint point = shape.Points[i];
                localPoints[i] = new Point(
                    point.X * cellSize, point.Y * cellSize);
            }

            Paint(new Shape(localPoints), color);            
        }

        private void Paint(IShape shape, Color color)
        {
            Debug.Assert(shape != null, "shape must not be null");
            Debug.Assert(color != null, "color must not be null");
            Debug.Assert(shape.Points != null, "shape point array must not be null");

            if (shape.Points.Length == 0)
            {
                return;
            }

            if (shape.Points.Length == 1)
            {
                if (IsContainedInBoard(shape.Points[0]))
                {
                    Paint(shape.Points[0], color);
                }                
                return;
            }

            for (Int32 i = 0; i < shape.Points.Length; i++)
            {
                IPoint from = shape.Points[i];
                IPoint to;
                if (i < shape.Points.Length - 1)
                {
                    to = shape.Points[i + 1];
                }
                else
                {
                    to = shape.Points[0];
                }

                Debug.Assert(from != null && to != null, "All the points of the figure must not be null");

                PaintLine(from, to, color);
            }            
        }

        private IShape LocalShape(Int32 x, Int32 y, IShape shape)
        {
            IPoint[] localPoints = new IPoint[shape.Points.Length];
            for (Int32 i = 0; i < shape.Points.Length; i++)
            {
                IPoint point = shape.Points[i];
                localPoints[i] = new Point(
                    x * cellSize + (point.X * (cellSize - 1) / 100),
                    y * cellSize + (point.Y * (cellSize - 1) / 100));
            }
            return new Shape(localPoints);
        }

        private void PaintLine(IPoint from, IPoint to, Color color)
        {
            Debug.Assert(from != null, "from must not  be null");
            Debug.Assert(to != null, "to must not  be null");
            Debug.Assert(color != null, "color must not be null");

            int dx = to.X - from.X;
            int dy = to.Y - from.Y;
            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xInc = dx / (float)steps;
            float yInc = dy / (float)steps;

            if (IsContainedInBoard(from))
            {
                Paint(from, color);
            }

            float x = from.X;
            float y = from.Y;            
            for (int i = 0; i < steps; i++)
            {
                x = x + xInc;
                y = y + yInc;
                int newX = (int) Math.Round(x);
                int newY = (int) Math.Round(y);                
                if (IsContainedInBoard(newX, newY))
                {
                    Paint(newX, newY, color);
                }
            }
        }

        private void Paint(IPoint point, Color color)
        {
            Debug.Assert(point != null, "point must not be null");
            Debug.Assert(IsContainedInBoard(point), "point is not contained in board");

            Paint(point.X, point.Y, color);            
        }

        private void Paint(int x, int y, Color color)
        {
            Debug.Assert(IsContainedInBoard(x, y), "point is not contained in board");
            
            board.PaintPoint(x, y, color);            
        }

        private Boolean IsContainedInBoard(int x, int y)
        {
            return board.IsInBoard(x, y);
        }

        private Boolean IsContainedInBoard(IPoint point)
        {
            Debug.Assert(point != null, "point must not be null");

            return IsContainedInBoard(point.X, point.Y);
        }
    }
}
