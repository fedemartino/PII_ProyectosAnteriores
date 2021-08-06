using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Un persistidor de imagenes.
    /// </summary>
    public interface IPicturePersister
    {
        /// <summary>
        /// Persiste la imagen.
        /// </summary>
        /// <param name="picture">la imagen, distinto de nulo</param>
        /// <param name="fileName">el nombre del archivo, distinto de nulo</param>
        void Persist(IPicture picture, String fileName);
    }
}
