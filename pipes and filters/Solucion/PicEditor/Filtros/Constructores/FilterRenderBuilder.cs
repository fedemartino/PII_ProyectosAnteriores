using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicEditor.Filtros.Constructores
{
    class FilterRenderBuilder : FilterBuilder
    {

        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            FilterRender f = new FilterRender(ObtenerNombreFiltro(tag.Atributos));
            return f;
        }
    }
}
