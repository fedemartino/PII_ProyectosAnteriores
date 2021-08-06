using System;
using System.Collections.Generic;
using System.Text;

namespace PainterLib
{
    /// <summary>
    /// Pinta figuras.
    /// </summary>		
    /// <remarks>
    /// No se especifica como se pinta la figura. Cada pintor puede pintar figuras de distintas
    /// maneras y en distintos lugares.
    /// </remarks>
    public interface IPainter
    {
        /// <summary>
        /// Pinta una figura dentro de una celda específica.       
        /// </summary>       
        /// <remarks>
        /// El pintor debe conocer previamente un tamanio de celda. Cuando se llama
        /// a este metodo, el pintor pintara la figura enteramente dentro de la celda
        /// identificada por el parametro <code>cell</code>. 
        /// Esto permite que la figura este expresada en coordenadas relativas a la celda.
        /// </remarks>
        /// <param name="cell">La coordenada de la celda</param>
        /// <param name="shape">La figura</param>
        /// <param name="color">El color</param>
        void PaintInCell(IPoint cell, IShape shape, Color color);

        /// <summary>
        /// Pinta una figura sobre toda la pizarra.
        /// </summary>
        /// <param name="shape">La figura</param>
        /// <param name="color">El color</param>
        void PaintInBoard(IShape shape, Color color);

        /// <summary>
        /// Borra todo lo pintado.
        /// </summary>
        void StartOver();
    }
}
