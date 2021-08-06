using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing
{
    /// <summary>
    /// Una acci�n gen�rica.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Realiza la acci�n.
        /// </summary>
        /// <remarks>
        /// La acci�n debe tener todo le necesario para ejecutarse.
        /// </remarks>
        void Perform();
    }
}
