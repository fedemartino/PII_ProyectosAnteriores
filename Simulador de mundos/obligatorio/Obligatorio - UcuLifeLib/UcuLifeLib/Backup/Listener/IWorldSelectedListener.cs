using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib.Listener
{
    public interface IWorldSelectedListener : IListener
    {
        /// <summary>
        /// Invocado cuando un mundo es seleccionado en la interfaz de UcuLife.
        /// </summary>
        /// <param name="worldName">el nombre del mundo</param>
        void WorldSelected(String worldName);
    }
}
