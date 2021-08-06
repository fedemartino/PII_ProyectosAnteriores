using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using PicEditor.Filtros.Pipes;

namespace PicEditor.Filtros.Constructores
{
    class PipeNullBuilder : PipeBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            PipeNull p = new PipeNull(ObtenerNombrePipe(tag.Atributos));
            return p;
        }
    }
}
