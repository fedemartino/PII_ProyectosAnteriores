using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Cara una imagen a partir de un nombre.
    /// </summary>
    public interface IPictureProvider
    {
        /// <summary>
        /// Lee la imagen identificada por el nombre y la carga en la imagen pasada por parametro.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Si el tamanio de la imagen leida no coincide con el tamanio de la imagen pasada por 
        /// parametro, se truncara la imagen leida para que entre en la pasada por parametro.
        /// </para>
        /// <para>
        /// Normalmente, la imagen pasada por parametro es una imagen recien creada.
        /// </para>
        /// </remarks>
        /// <param name="name">el nombre de la imagen a leer</param>
        /// <param name="picture">una imagen sobre la cual cargar la imagen leida</param>
        void ReadIntoImage(String name, IPicture picture);               
    }
}
