using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Una cañería a través de la cual pasa una imagen.
    /// </summary>
    public interface IPipe
    {        
        /// <summary>
        /// Envía la imagen a través de la cañería.
        /// </summary>
        /// <param name="picture">la imagen a enviar</param>
        IPicture Send(IPicture picture);
        /// <summary>
        /// El nombre del pipe.
        /// </summary>
        String Name { get; }
    }
}
