using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing
{
    /// <summary>
    /// Una acción genérica.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Realiza la acción.
        /// </summary>
        /// <remarks>
        /// La acción debe tener todo le necesario para ejecutarse.
        /// </remarks>
        void Perform();
    }
}
