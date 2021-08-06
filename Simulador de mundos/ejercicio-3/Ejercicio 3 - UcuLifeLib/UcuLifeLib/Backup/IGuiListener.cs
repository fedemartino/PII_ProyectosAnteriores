using System;
using System.Collections.Generic;
using System.Text;
using PainterLib;

namespace UcuLifeLib
{

    /// <summary>
    /// Un observador de eventos en la interfaz de UcuLife.
    /// </summary>
    public interface IGuiListener
    {
        /// <summary>
        /// Invocado cuando un mundo es seleccionado en la interfaz de UcuLife.
        /// </summary>
        /// <param name="worldName">el nombre del mundo</param>
        void WorldSelected(String worldName);

        /// <summary>
        /// Invocado cuando una cosa es seleccionada en la interfaz de UcuLife.
        /// </summary>
        /// <param name="thingName">el nombre de la cosa</param>
        void ThingSelected(String thingName);

        /// <summary>
        /// Invocado cuando se selecciona una celda de la pizarra.
        /// </summary>
        /// <param name="selectedCell">la celda seleccionada</param>
        void CellSelected(IPoint selectedCell);
    }
}
