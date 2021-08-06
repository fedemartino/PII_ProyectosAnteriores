using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib
{
    /// <summary>
    /// Una accion.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Ejecuta la accion.
        /// </summary>
        void Run();

        /// <summary>
        /// Retorna si la accion ha terminado o debe volver a ejecutarse.
        /// </summary>
        Boolean Done { get; }
    }
}
