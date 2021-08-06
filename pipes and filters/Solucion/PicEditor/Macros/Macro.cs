using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicEditor.Filtros;
using PicfilLib;
using System.Diagnostics;

namespace PicEditor
{
    class Macro : NamedObject, Macros.ISecuencia, IFilter
    {
        private PicfilLib.IPipe pipe;       
        int i;
        /// <summary>
        /// Recibe un nombre y una cañeria con los filtros a aplicar. Los recibe desde un archivo.
        /// </summary>
        /// <param name="name">Nombre del macro</param>
        /// <param name="firstStep">Cañeria que contiene los filtros para aplicar</param>
        public Macro(string name, IPipe firstStep) : this(name)
        {
            this.pipe = firstStep;
        }
        /// <summary>
        /// Recibe el nombre del macro y genera un pipe null el cual va a ser el tope de la cañeria
        /// </summary>
        /// <param name="name">Nombre del macro</param>
        public Macro(string name) : base (name) 
        {
            i = 0;
            this.pipe = new PicEditor.Filtros.Pipes.PipeNull("Fin_Macro_" + name);                       
        }
        /// <summary>
        /// Agrega filtros los cuales van a ser guardados en el macro. Lo hace agregando pipes a la cañeria.
        /// </summary>
        /// <param name="nextStep">Filtro a ser agregado</param>

        public void AddStep(PicfilLib.IFilter nextStep)
        {
            Debug.Assert(nextStep != null);
            i++;
            Filtros.Pipes.PipeSerial pipeNuevo = new PicEditor.Filtros.Pipes.PipeSerial("paso" + i + "_macro_" + this.name, nextStep, this.pipe);
            this.pipe = pipeNuevo;
        }
        /// <summary>
        /// Devuelve el primer IPipe del macro
        /// </summary>
        public IPipe FirstStep
        {
            get { return this.pipe; }
        }
        
        #region Miembros de IFilter

        /// <summary>
        /// Aplica el macro
        /// </summary>
        /// <param name="image">Imagen sobre la cual se debe aplicar el macro</param>
        /// <returns>Imagen con el macro aplicado</returns>
        public IPicture Filter(IPicture image)
        {
            return this.pipe.Send(image);
        }

        #endregion
    }
}
