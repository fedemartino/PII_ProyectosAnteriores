using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TagParser;
using System.Collections;
using PicEditor.Filtros.Constructores;

namespace PicEditor
{
    class FileReader
    {
        private Downloader downloader;
        private XmlParser parser;
        private ArrayList listaTags;

        public FileReader()
        {
            this.parser = new XmlParser();
            this.downloader = null;
        }

        public void LeerArchivo(string rutaArchivo)
        {
            downloader = new Downloader(rutaArchivo);
            string archivo = downloader.Download();
            listaTags = parser.ParsearTexto(archivo);
        }

        public Hashtable InterpretarTags()
        {
            Debug.Assert(downloader != null);
            listaTags.RemoveAt(0);
            listaTags.RemoveAt(0);
            
            Hashtable hashFiltros = new Hashtable();
            Hashtable hashObjetos = new Hashtable();

            //Hashtable constructores = Filtros.StaticMembers.Constructores();
            Hashtable constructores = Persistencia.TagDatabase.TagToObject();
            ITagBuilder constructor;

            foreach (Tag t in listaTags)
            {
                constructor = (ITagBuilder)constructores[t.Nombre];
                constructor.BuildAndPersist(t, ref hashFiltros);
            }
            return hashFiltros;
        }
    }
}
