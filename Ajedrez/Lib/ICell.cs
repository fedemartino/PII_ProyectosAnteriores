using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public interface ICell
    {
        /// <summary>
        /// Agrega una pieza a la celda
        /// </summary>
        /// <param name="piece">Pieza a agregar</param>
        void AddPiece(IPiece piece);
        /// <summary>
        /// Quita la pieza de la celda
        /// </summary>
        void RemovePiece();
        /// <summary>
        /// Obtiene el color de la celda
        /// </summary>
        /// <returns>Color de la celda</returns>
        Color GetColor();
        /// <summary>
        /// Verifica si la celda contiene una pieza
        /// </summary>
        /// <returns>Devuelve true si la celda contiene una pieza</returns>
        Boolean HasPiece();
        /// <summary>
        /// Obtiene la pieza en la celda
        /// </summary>
        /// <returns>Pieza</returns>
        IPiece GetPiece();

    }
}
