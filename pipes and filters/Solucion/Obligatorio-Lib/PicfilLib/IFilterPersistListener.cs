using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Escucha eventos de persistencia de filtros.
    /// </summary>
    public interface IFilterPersistListener
    {
        /// <summary>
        /// Persiste los filtros actuales en el archivo pasado por parametro.
        /// </summary>
        /// <param name="fileName">el nombre del archivo donde guardar la imagen</param>
        void PersistFilters(String fileName);
    }
}
