using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using System.Diagnostics;

namespace PicEditor.Filtros
{
    class FilterPipe : NamedObject, IFilter
    {
        IPipe pipe;
        /// <summary>
        /// El filtro envia una imagen a una cañeria y luego retorna la misma imagen. 
        /// </summary>
        /// <param name="pipe">Cañerìa a la cual se le va a enviar la imagen</param>
        public FilterPipe(IPipe pipe):this("filtroPipe")
        {
            this.pipe = pipe;
        }
        public FilterPipe(String name, IPipe pipe) : base (name)
        {
            this.pipe = pipe;
        }
        public FilterPipe(String name) : base (name)
        {
        }
        /// <summary>
        /// Envia la imagen a la cañeria pipe y retorna la misma imagen.
        /// </summary>
        /// <param name="image">Imagen a la que se le va a aplicar el filtro</param>
        /// <returns></returns>
        public IPicture Filter(IPicture image)
        {
            Debug.Assert(image != null);
            pipe.Send(image);
            return image;
        }

    }
}
