using System;
using System.Collections.Generic;
using System.Text;

namespace PainterLib
{
    /// <summary>
    /// Una figura.
    /// </summary>
    /// <remarks>
    /// Las figuras quedan determinadas a partir de los vertices de la figura, que
    /// deben proveerse en orden.
    /// </remarks>
    public interface IShape
    {
        /// <summary>
        /// Retorna los vertices de la figura.
        /// </summary>		
        IPoint[] Points { get; }
    }
}
