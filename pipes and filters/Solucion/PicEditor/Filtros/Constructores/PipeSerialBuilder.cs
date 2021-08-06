using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicEditor.Filtros.Pipes;
using PicfilLib;
using System.Collections;
using TagParser;

namespace PicEditor.Filtros.Constructores
{
    class PipeSerialBuilder : PipeBuilder
    {
        public override object Build(TagParser.Tag tag, System.Collections.Hashtable hashFiltros)
        {
            IPipe nextPipe = ObtenerNextPipe(tag.Atributos, "next", hashFiltros);
            IFilter filtro = ObtenerFiltro(tag.Atributos, hashFiltros);
            PipeSerial p = new Pipes.PipeSerial(ObtenerNombrePipe(tag.Atributos), filtro, nextPipe);
            return p;
        }
        protected IPipe ObtenerNextPipe(ArrayList atributos, string nombreAtributo, Hashtable hashPipes)
        {
            IPipe nextPipe = null;
            string nextPipeName = "";
            foreach (Atributo a in atributos)
            {
                if (a.Nombre.ToUpper() == nombreAtributo.ToUpper())
                {
                    nextPipeName = a.Valor;
                }
            }
            if (hashPipes.Contains(nextPipeName))
            {
                nextPipe = (IPipe)hashPipes[nextPipeName];
            }
            return nextPipe;
        }
        /// <summary>
        /// Devuelve un IFilter del hashtable
        /// <remarks>hashFiltros</remarks>
        /// correspondiente al indicado en los atributos
        /// </summary>
        /// <param name="atributos">lista de atributos del tag</param>
        /// <param name="hashFiltros">hashtable con los filtros creados hasta ahora</param>
        /// <returns></returns>
        protected IFilter ObtenerFiltro(ArrayList atributos, Hashtable hashFiltros)
        {
            IFilter filtro = null;
            string nombreFiltro = "";
            foreach (Atributo a in atributos)
            {
                if (a.Nombre.ToUpper() == "filter".ToUpper())
                {
                    nombreFiltro = a.Valor;
                }
            }
            if (hashFiltros.Contains(nombreFiltro))
            {
                filtro = (IFilter)hashFiltros[nombreFiltro];
            }
            return filtro;
        }
    }
}
