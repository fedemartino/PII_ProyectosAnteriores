using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace PainterLib
{
    /// <summary>
    /// El modelo de la pizzarra. Referirse a la interfaz <see cref="IBoard"/> por documentación
    /// de sus métodos.
    /// </summary>
    public sealed class BoardModel: IBoard, ICloneable
    {
        private readonly Color NOT_PAINTED = new Color(0,0,0);

        private readonly Int32 maxX;

        private readonly Int32 maxY;

        private readonly Color[,] dots;

        private Color this[int x, int y]
        {
            get
            {
                return dots[x, y];
            }
            set
            {
                dots[x, y] = value;
                changed = true;
            }
        }

        private Boolean changed;

        /// <summary>
        /// Retorna si la pizarra cambio desde la ultima vez que se 
        /// invoco a este metodo.
        /// </summary>
        public Boolean Changed 
        {           
            get 
            { 
                Boolean wasChanged = changed; 
                changed = false; 
                return wasChanged; 
            }
        }
        
        /// <summary>
        /// Crea un nuevo modelo de pizzarra.
        /// </summary>
        /// <param name="maxX">La máxima coordenada X</param>
        /// <param name="maxY">La máxima coordenada Y</param>
        public BoardModel(Int32 maxX, Int32 maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.dots = new Color[maxX, maxY];
            ClearBoard();
        }

        public Boolean IsPainted(Int32 x, Int32 y)
        {            
            return IsInBoard(x,y) && dots[x, y] != NOT_PAINTED;
        }
       
        public void ClearPoint(Int32 x, Int32 y)
        {
            Debug.Assert(IsInBoard(x, y), "Invalid board coordinates");

            lock (this)
            {
                this[x, y] = NOT_PAINTED;
            }

            Debug.Assert(!IsPainted(x, y));
        }

        public void ClearBoard()
        {
            for (Int32 x = 0; x < MaxX; x++)
            {
                for (Int32 y = 0; y < MaxY; y++)
                {
                    ClearPoint(x, y);
                }
            }
        }
     
        public Color GetColor(Int32 x, Int32 y)
        {
            Debug.Assert(IsInBoard(x, y), "Invalid board coordinates");
            Debug.Assert(IsPainted(x, y), "No color since the point is not painted");
            
            return this[x, y];
        }
       
        public void PaintPoint(Int32 x, Int32 y, Color color)
        {
            Debug.Assert(IsInBoard(x, y), "Invalid board coordinates");
            Debug.Assert(color != null, "Invalid Color");

            lock (this)
            {
                this[x, y] = color;
            }

            Debug.Assert(IsPainted(x, y), "Point is not painted");
        }
        
        public Boolean IsInBoard(Int32 x, Int32 y)
        {
            return (x >= 0) && (x < MaxX) && (y >= 0) && (y < MaxY);
        }

        public Int32 MaxX
        {
            get
            {
                return maxX;
            }
        }
                
        public Int32 MaxY
        {
            get
            {
                return maxY;
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            BoardModel newmodel = new BoardModel(maxX, maxY);
            for (Int32 x = 0; x < MaxX; x++)
            {
                for (Int32 y = 0; y < MaxY; y++)
                {
                    newmodel.dots[x, y] = dots[x, y];                    
                }
            }
            return newmodel;
        }

        #endregion
    }
}
