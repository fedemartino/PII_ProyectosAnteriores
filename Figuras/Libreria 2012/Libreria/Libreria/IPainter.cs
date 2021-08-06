using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Drawing
{
    /// <summary>
    /// Pinta figuras.
    /// </summary>		
    /// <remarks>
    /// No se especifica como se pinta la figura. Cada pintor puede pintar figuras de disintas
    /// maneras y en distintos lugares.
    /// </remarks>
    public interface IPainter
    {
        /// <summary>
        /// Pide al pintor que pinte la figura.
        /// </summary>		
        /// <param name="shape">La figura a pintar.</param>
        /// <param name="color">El color de la figura.</param>
        void Paint(IShape shape, Color color);
    }
}
