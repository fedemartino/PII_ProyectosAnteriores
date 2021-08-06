using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    /// <summary>
    /// Escucha eventos relacionados con macros.
    /// </summary>
    public interface IMacroListener
    {
        /// <summary>
        /// Empieza a grabar un macro.
        /// </summary>
        /// <param name="macroName">el nombre del macro</param>
        void RecordMacro(String macroName);

        /// <summary>
        /// Termina de grabar el macro actual.
        /// </summary>
        /// <remarks>
        /// Si no hay un macro actual, no hace nada.
        /// </remarks>
        void StopRecordMacro();
    }
}
