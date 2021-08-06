using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public interface IPiece
    {
        /// <summary>
        /// Indica si la posición nueva de la pieza es válida
        /// </summary>
        /// <param name="newPos">Posición deseada para la pieza</param>
        /// <param name="board">El tablero donde se encuentra la pieza</param>
        /// <returns>Devuelve true si el movimiento es válido</returns>
        bool IsValidMove(Coordenada newPos, IBoard board);
        /// <summary>
        /// Devuelve una lista de posibles coordenadas a donde la pieza puede
        /// moverse en base a la posición actual
        /// </summary>
        /// <param name="board">El tablero donde se encuentra la pieza</param>
        /// <returns>lista de Coordenadas posibles</returns>
        List<Coordenada> ValidMoves(IBoard board);
        /// <summary>
        /// Mueve la pieza de lugar
        /// </summary>
        /// <param name="newPos">Nueva posición de la pieza</param>
        void Move(Coordenada newPos);
        /// <summary>
        /// Obtiene la figura que representa la pieza
        /// </summary>
        /// <returns>Figura que representa la pieza</returns>
        IShape GetShape();

    }
}
