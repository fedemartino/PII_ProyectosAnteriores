using System;
using System.Collections.Generic;
using System.Text;
using PainterLib;

namespace UcuLifeLib.Listener
{
    public interface ICellSelectedListener : IListener
    {
        /// <summary>
        /// Invocado cuando se selecciona una celda de la pizarra.
        /// </summary>
        /// <param name="selectedCell">la celda seleccionada</param>
        void CellSelected(IPoint selectedCell);
    }
}
