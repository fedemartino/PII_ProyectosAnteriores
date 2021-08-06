using System;
using System.Collections;
using System.Text;
using Drawing;
using System.Threading;
using System.Diagnostics;

namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa la interfaz IAction. Se encarga de pausar 
    /// las acciones el tiempo indicado 
    /// </summary>
    public class Pausar : IAction
    {
        private Int32 tiempoAPausar;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="tiempoAPausar">Variable entera que indica los milisegundos que se pausará</param>
        public Pausar(Int32 tiempoAPausar)
        {
            this.tiempoAPausar = tiempoAPausar;
            invariantes();
        }

        /// <summary>
        /// Método que ejecuta la acción de pausar
        /// </summary>
        public void Perform()
        {
            invariantes();
            Thread.Sleep(tiempoAPausar);
            invariantes();
        }

        private void invariantes()
        {
            Debug.Assert(tiempoAPausar > 0, "El tiempo a pausar no puede ser menor a cero.");
        }
    }
}
