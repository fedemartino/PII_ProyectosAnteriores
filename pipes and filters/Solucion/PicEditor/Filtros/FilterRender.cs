using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using System.Diagnostics;

namespace PicEditor.Filtros
{
    class FilterRender : NamedObject, IFilter
    {
        IPictureRenderer desplegador;
        /// <summary>
        /// El filtro recibe una imagen, la despliega en pantalla y luego retorna la misma imagen.
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a aplicar el filtro</param>
        /// <returns></returns>
        /// 
        public FilterRender():this("filtroRender", new PictureFormRenderer())
        { }
        public FilterRender(String name) : this(name, new PictureFormRenderer())
        {
        }
        public FilterRender (String name, IPictureRenderer desplegador) : base (name)
        {
            this.desplegador = desplegador;
        }
        public FilterRender(IPictureRenderer desplegador):this("desplegador")
        {
            this.desplegador = desplegador;
        }

        public IPicture Filter(IPicture image)
        {
            Debug.Assert(image != null);
            desplegador.Render(image);
            return image;
        }
        
    }
}
