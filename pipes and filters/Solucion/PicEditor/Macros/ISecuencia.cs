using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;

namespace PicEditor.Macros
{
    interface ISecuencia
    {
        /// <summary>
        /// Agrega un paso a la secuencia.
        /// </summary>
        /// <param name="nextStep"></param>
        void AddStep(IFilter nextStep);        
    }
}
