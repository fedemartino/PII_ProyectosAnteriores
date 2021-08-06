using System;
using System.Collections.Generic;
using System.Text;

namespace PainterLib
{
    /// <summary>
    /// Un control grafico que puede desplegar el contenido de una pizarra.
    /// </summary>
    public interface IGui
    {
        /// <summary>
        /// Abre y muestra el control grafico.
        /// </summary>
        /// <remarks>
        /// Este metodo debe invocarse para que sea posible ver el componente por
        /// pantalla. En otro caso, no se vera nada.
        /// </remarks>
        void Open();

        /// <summary>
        /// Dibuja la pizarra en pantalla.
        /// </summary>
        /// <param name="board">La pizarra.</param>
        void Redraw(IBoard board);
    }
}
