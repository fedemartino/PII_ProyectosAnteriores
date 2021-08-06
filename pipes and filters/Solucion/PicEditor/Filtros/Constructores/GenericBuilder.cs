using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using PicfilLib;

namespace PicEditor.Filtros.Constructores
{
    class GenericBuilder<T> where T: class
    {
        public T Construir(Object[] args)
        {
            T objetoNuevo = Activator.CreateInstance(typeof(T), args) as T;
            return objetoNuevo;
        }
    }
}
