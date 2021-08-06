using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing
{
    /// <summary>
    /// Un ejecutor de acciones.
    /// </summary>
    /// <remarks>
    /// Encola las acciones provistas vía <code>AddAction(IAction)</code> y las ejecuta
    /// en forma sencuencial al ejecutar <code>Execute()</code>.
    /// </remarks>
    public interface IExecutor
    {
        /// <summary>
        /// Encola una acción para ser ejecutada cuando se llame <code>Execute()</code>.
        /// </summary>
        /// <param name="action">la acción a encolar.</param>
        void AddAction(IAction action);

        /// <summary>
        /// Ejecuta las acciones encoladas en el ejecutor.
        /// </summary>
        /// <remarks>
        /// El órden en que se encolaron las acciones es respetado.
        /// </remarks>
        void Execute();
    }
}
