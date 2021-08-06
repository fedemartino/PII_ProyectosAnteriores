using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Escucha eventos de persistencia de imagenes.
    /// </summary>
    public interface IPicturePersistListener
    {
        /// <summary>
        /// Persiste la imagen actual en el archivo pasado por parametro.
        /// </summary>
        /// <remarks>
        /// Si no hay un macro actual, no hace nada.
        /// </remarks>
        /// <param name="fileName">el nombre del archivo donde guardar la imagen</param>
        void PersistPicture(String fileName);
    }
}
