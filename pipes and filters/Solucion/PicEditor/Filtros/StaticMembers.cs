using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;
using System.Collections;
using TagParser;

namespace PicEditor.Filtros
{
    static class StaticMembers
    {
        public enum TipoFiltro
        {
            Negative,
            BlackWhite,
            Greyscale,
            Blur,
            Emboss,
            Render,
            Tags
        }
        public enum TipoPipe
        {
            Serial,
            Fork,
            Null
        }
        /// <summary>
        /// Genero un filtro con los parametros por defecto
        /// </summary>
        /// <param name="tipo">Tipo de filtro que se debe generar</param>
        /// <returns>Filtro del tipo 
        /// <code>type</code>
        /// </returns>
        public static IFilter GenerarFiltro(TipoFiltro type)
        {
            IFilter filtro = null;
            switch (type)
            {
                case TipoFiltro.Negative:
                    filtro = new FilterNegative();
                    break;
                case TipoFiltro.BlackWhite:
                    filtro = new FilterBW();
                    break;
                case TipoFiltro.Greyscale:
                    filtro = new FilterGreyscale();
                    break;
                case TipoFiltro.Blur:
                    filtro = new FilterBlur();
                    break;
                case TipoFiltro.Emboss:
                    filtro = new FilterEmboss();
                    break;
                case TipoFiltro.Render:
                    filtro = new FilterRender();
                    break;
            }
            return filtro;
        }
    }
}
