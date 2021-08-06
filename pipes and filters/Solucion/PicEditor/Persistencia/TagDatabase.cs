using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicEditor.Filtros.Constructores;
using System.Collections;

namespace PicEditor.Persistencia
{
    static class TagDatabase
    {
        private const string filterNegative = "filter-negative";
        private const string filterBW = "filter-blackwhite";
        private const string filterGreyscale = "filter-greyscale";
        private const string filterBlur = "filter-blur";
        private const string filterEmboss = "filter-emboss";
        private const string filterTags = "filter-tags";
        private const string filterRender = "filter-render";
        private const string filterPipe = "filter-pipe";
        private const string pipeSerial = "pipe-serial";
        private const string pipeFork = "pipe-fork";
        private const string pipeNull = "pipe-null";
        private const string macro = "macro";

        private static Hashtable tagToObjectHash;
        private static Hashtable objectToTagHash;
        ////private static Hashtable tagToObjectHashGenerics;


        static TagDatabase()
        {
            tagToObjectHash = new Hashtable();
            tagToObjectHash.Add(filterNegative, new Filtros.Constructores.FilterNegativeBuilder());
            tagToObjectHash.Add(filterBW, new Filtros.Constructores.FilterBWBuilder());
            tagToObjectHash.Add(filterGreyscale, new Filtros.Constructores.FilterGreyscaleBuilder());
            tagToObjectHash.Add(filterBlur, new Filtros.Constructores.FilterBlurBuilder());
            tagToObjectHash.Add(filterEmboss, new Filtros.Constructores.FilterEmbossBuilder());
            tagToObjectHash.Add(filterRender, new Filtros.Constructores.FilterRenderBuilder());
            tagToObjectHash.Add(filterPipe, new Filtros.Constructores.FilterPipeBuilder());
            tagToObjectHash.Add(pipeSerial, new Filtros.Constructores.PipeSerialBuilder());
            tagToObjectHash.Add(pipeFork, new Filtros.Constructores.PipeForkBuilder());
            tagToObjectHash.Add(pipeNull, new Filtros.Constructores.PipeNullBuilder());
            tagToObjectHash.Add(macro, new Filtros.Constructores.MacroBuilder());

            objectToTagHash = new Hashtable();
            objectToTagHash.Add(typeof(Filtros.FilterNegative), filterNegative);
            objectToTagHash.Add(typeof(Filtros.FilterBW), filterBW);
            objectToTagHash.Add(typeof(Filtros.FilterGreyscale), filterGreyscale);
            objectToTagHash.Add(typeof(Filtros.FilterBlur), filterBlur);
            objectToTagHash.Add(typeof(Filtros.FilterEmboss), filterEmboss);
            objectToTagHash.Add(typeof(Filtros.FilterRender), filterRender);
            objectToTagHash.Add(typeof(Filtros.Pipes.PipeSerial), pipeSerial);
            objectToTagHash.Add(typeof(Filtros.Pipes.PipeNull), pipeNull);
            objectToTagHash.Add(typeof(Filtros.Pipes.PipeFork), pipeFork);
            objectToTagHash.Add(typeof(Macro), macro);

            //tagToObjectHashGenerics = new Hashtable();
            //TagObjectFactory t;
            //t = new TagObjectFactory();
            //t.Add("Name", typeof(string), null);
            //tagToObjectHashGenerics.Add(filterBlur, t);
            
            //Func<string, Object> f = (str) => Double.Parse(str);
            //t.Add("threshold", typeof(double), f);

            
        }
        public static Hashtable TagToObject()
        {
            return tagToObjectHash;
        }
        public static Hashtable ObjectToTag()
        {
            return objectToTagHash;
        }
    }
}
