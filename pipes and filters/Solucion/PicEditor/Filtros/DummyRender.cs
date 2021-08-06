using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;

namespace PicEditor.Filtros
{
    public class DummyRender : IPictureRenderer
    {
        bool verificacion;
        public DummyRender()
        {
            this.verificacion = false;
        }

        public bool Verificacion
        {
            get {return verificacion;}
        }

        public void Render (IPicture imagen)
        {
            verificacion = true;
        }
    }
}
