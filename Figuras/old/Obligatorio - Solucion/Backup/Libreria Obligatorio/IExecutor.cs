using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing
{
    /// <summary>
    /// Un ejecutor de acciones.
    /// </summary>
    /// <remarks>
    /// Encola las acciones provistas v�a <code>AddAction(IAction)</code> y las ejecuta
    /// en forma sencuencial al ejecutar <code>Execute()</code>.
    /// </remarks>
    public interface IExecutor
    {
        /// <summary>
        /// Encola una acci�n para ser ejecutada cuando se llame <code>Execute()</code>.
        /// </summary>
        /// <param name="action">la acci�n a encolar.</param>
        void AddAction(IAction action);

        /// <summary>
        /// Ejecuta las acciones encoladas en el ejecutor.
        /// </summary>
        /// <remarks>
        /// El �rden en que se encolaron las acciones es respetado.
        /// </remarks>
        void Execute();
    }
}
