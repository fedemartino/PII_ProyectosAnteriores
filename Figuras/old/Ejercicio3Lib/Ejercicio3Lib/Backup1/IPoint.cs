using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing
{
    /// <summary>
    /// Un punto de un espacio de dos dimensiones (X e Y).
    /// </summary>
    public interface IPoint
    {
        /// <summary>
        /// Retorna la coordenada X.
        /// </summary>		
        Int32 X { get; }

        /// <summary>
        /// Retorna la coordenada Y.
        /// </summary>		
        Int32 Y { get; }
        
    }
}
