using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing
{
    /// <summary>
    /// Una figura esta compuesta por todos los vertices de la figura.
    /// </summary>	
    public interface IShape
    {
        /// <summary>
        /// Retorna los vertices de la figura.
        /// </summary>		
        IPoint[] Points { get; }

    }

}
