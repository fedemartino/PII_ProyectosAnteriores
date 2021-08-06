using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Reflection;
using PicfilLib;

namespace PicEditor.Persistencia
{
    class FilterPersister : IFilterPersistListener
    {
        Hashtable filtros;
        Hashtable filterTag;
        Hashtable persistedFilters;
        XmlTextWriter writer;
        public FilterPersister(Hashtable filtros, Hashtable filterTag)
        {
            this.filtros = filtros;
            this.persistedFilters = new Hashtable();
            this.filterTag = filterTag;
        }
        public void PersistFilters(string fileName)
        {
            persistedFilters.Clear();
            this.writer = new XmlTextWriter(fileName, null);
            this.writer.WriteStartDocument();
            this.writer.WriteStartElement("root");
            foreach (DictionaryEntry d in filtros)
            {
                PersistirFiltro((PersistantObject)d.Value);
            }
            this.writer.WriteEndDocument();
            this.writer.Close();
        }
        /// <summary>
        /// Crea un nuevo elemento en un documento XML con los datos del filtro
        /// </summary>
        /// <param name="filtro">Filtro que se debe persistir</param>
        private void PersistirFiltro(PersistantObject filtro)
        {
            PropertyInfo[] props = (filtro.GetType()).GetProperties();
            Object obj;
            foreach (PropertyInfo pi in props)
            {
                obj = pi.GetValue(filtro, null);
                if (obj is PersistantObject)
                {
                    PersistirFiltro((PersistantObject)obj);
                }
            }
            Type t = filtro.GetType();
            if ((filterTag[t] != null) && (persistedFilters[filtro] == null))
            {
                writer.WriteStartElement(filterTag[t].ToString());
                foreach (PropertyInfo pi in props)
                {
                    writer.WriteAttributeString(pi.Name, pi.GetValue(filtro, null).ToString());
                }
                writer.WriteEndElement();
                persistedFilters.Add(filtro, filtro);
            }
        }
    }
}
