using System;

namespace PicfilLib
{
    /// <summary>
    /// Un filtro grafico.
    /// </summary>
    /// <remarks>
    /// Un filtro procesa una imagen, creando opcionalmente una nueva imagen.
    /// </remarks>
    public interface IFilter
    {
        /// <summary>
        /// El nombre del filtro.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Procesa la imagen pasada por parametro y retorna la misma imagen o una nueva.
        /// </summary>
        /// <param name="image">La imagen a procesar</param>
        /// <returns>La misma imagen o una nueva imagen creada por el filtro</returns>
        IPicture Filter(IPicture image);
    }
}
