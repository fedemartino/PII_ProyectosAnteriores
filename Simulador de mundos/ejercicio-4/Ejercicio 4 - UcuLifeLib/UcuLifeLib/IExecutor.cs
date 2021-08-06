using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib
{
    /// <summary>
    /// Un ejecutor de acciones.
    /// </summary>
    public interface IExecutor
    {
        /// <summary>
        /// Agrega una accion para ser ejecutada por el ejecutor.
        /// </summary>
        /// <remarks>
        /// Una vez agregada, el ejecutor ejecutara la accion una y otra vez hasta 
        /// que su operacion <code>Done</code> retorne verdadero.
        /// <br/>
        /// Si se agrega mas de una accion, el ejecutor garantiza que las mismas
        /// se ejecutan en el orden en que fueron agregadas.
        /// </remarks>
        /// <param name="action">La accion.</param>
        void AddAction(IAction action);
        
        /// <summary>
        /// Retorna si la accion fue agregada a este ejecutor y aun sigue ejecutandose.
        /// </summary>
        /// <param name="action">La accion.</param>
        /// <returns>Verdadero si esta contenida en el ejecutor, falso en otro caso</returns>
        Boolean ContainsAction(IAction action);        
    }
}
