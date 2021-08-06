using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public interface IBoard
    {
        /// <summary>
        /// Obtiene la celda indicada del tablero
        /// </summary>
        /// <param name="x">coordenada X de la celda deseada</param>
        /// <param name="y">coordenada Y de la celda deseada</param>
        /// <returns>Celda del tablero</returns>
        ICell GetCell(int x, int y);
        /// <summary>
        /// Obtiene el ancho del tablero
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Obtiene el alto del tablero
        /// </summary>
        int Height { get; }

    }
}
