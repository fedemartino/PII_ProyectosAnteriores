using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TagParser;
using PicfilLib;
using PicEditor.Filtros.Pipes;

namespace PicEditor.Filtros.Constructores
{
    class PipeForkBuilder : PipeSerialBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            IPipe next1Pipe = ObtenerNextPipe(tag.Atributos, "next1", hashFiltros);
            IPipe next2Pipe = ObtenerNextPipe(tag.Atributos, "next2", hashFiltros);
            PipeFork p = new PipeFork(ObtenerNombrePipe(tag.Atributos), next1Pipe, next2Pipe);
            return p;
        }
    }
}
