using System;
using System.Collections.Generic;
using System.Text;

namespace PainterLib
{
    /// <summary>
    /// Un punto en el plano.
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
