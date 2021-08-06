using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Drawing
{
    /// <summary>
    /// Pinta figuras en un <see cref="IBoard"/>.
    /// </summary>    
    /// <remarks>
    /// La clase dibuja figuras dibujando líneas que unen los puntos de la figura. Por ésto
    /// es necesario que la figura retorne sus puntos en sentido horario o antihorario.
    /// </remarks>
    public sealed class BoardPainter: IPainter
    {       
        private readonly IBoard board;

        /// <summary>
        /// Crea una nueva instancia de <code>BoardPainter</code>.
        /// </summary>
        /// <param name="board">El <code>IBoard</code> donde mostrar la figura.</param>
        public BoardPainter(IBoard board)
        {
            Debug.Assert(board != null, "Board must not be null");

            this.board = board;
        }

        /// <summary>
        /// Despinta todos lo pintado por este pintor.
        /// </summary>
        public void RestartPainting()
        {
            board.ClearBoard();
        }

        /// <summary>
        /// Pinta la figura pasada por parámetro en el <code>IBoard</code>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// La figura pasada por parámetro no debe ser <code>null</code>. Ninguno de los puntos
        /// de la figura debe ser <code>null</code>.
        /// </para>
        /// <para>
        /// Si la figura no tiene puntos, el método retorna inmediatamente. Si tiene un único
        /// punto, pinta el punto y retorna. Si tiene más de un punto, pinta segmentos de recta
        /// entre los puntos de la figura en el órden en que son retornados.
        /// </para>
        /// </remarks>
        /// <param name="figure">La figura a pintar.</param>
        public void Paint(IShape shape, Color color)
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
