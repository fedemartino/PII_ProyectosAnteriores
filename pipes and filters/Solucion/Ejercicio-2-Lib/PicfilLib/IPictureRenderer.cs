using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Un desplegador de imagenes.
    /// </summary>
    /// <remarks>
    /// Se encarga de desplegar una imagen de alguna forma.
    /// </remarks>
    public interface IPictureRenderer
    {
        /// <summary>
        /// Despliega la imagen.
        /// </summary>
        /// <param name="picture">La imagen</param>
        void Render(IPicture picture);
    }
}
