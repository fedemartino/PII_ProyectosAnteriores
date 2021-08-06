using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Una ca�er�a a trav�s de la cual pasa una imagen.
    /// </summary>
    public interface IPipe
    {        
        /// <summary>
        /// Env�a la imagen a trav�s de la ca�er�a.
        /// </summary>
        /// <param name="picture">la imagen a enviar</param>
        IPicture Send(IPicture picture);
        /// <summary>
        /// El nombre del pipe.
        /// </summary>
        String Name { get; }
    }
}
