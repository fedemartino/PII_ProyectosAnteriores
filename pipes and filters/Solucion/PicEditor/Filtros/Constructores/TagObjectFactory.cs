using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagParser;
using System.Collections;

namespace PicEditor.Filtros.Constructores
{
    class TagObjectFactory
    {
        public class TagData
        {
            private string name;
            private Type type;
            private Func<string, object> funcion;
            public TagData(string name, Type type, Func<string, object> funcion)
            {
                this.name = name;
                this.type = type;
                this.funcion = funcion;
            }
            public object GetDato(ArrayList atributos, Hashtable hashFiltros)
            {
                string valorAtributo = "";
                foreach (Atributo a in atributos)
                {
                    if (a.Nombre.ToUpper() == this.name.ToUpper())
                    {
                        valorAtributo = a.Valor;
                    }
                }
                if (this.type == typeof(PersistantObject))
                {
                    return hashFiltros[valorAtributo];
                }
                else if (this.type == typeof(string))
                {
                    return valorAtributo;
                }
                else
                {
                    return this.funcion(valorAtributo);
                }
            }
        }
        private ArrayList argumentos;
        private ArrayList tagDatas;
        public TagObjectFactory()
        {
            this.argumentos = new ArrayList();
            this.tagDatas = new ArrayList();
        }
        public void Add(string name, Type type, Func<string, object> funcion)
        {
            Func<string, object> f = null;
            if (funcion != null)
            {
                f = funcion;
            }
            tagDatas.Add(new TagData(name, type, f));
        }
        public Object[] GetArgs(ArrayList atributos, Hashtable hashfiltros)
        {
            foreach(TagData t in tagDatas)
            {
                argumentos.Add(t.GetDato(atributos, hashfiltros));
            }
            return atributos.ToArray();
        }
    }
}
