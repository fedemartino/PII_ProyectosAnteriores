using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib.Listener
{
    public interface IThingSelectedListener : IListener
    {
        /// <summary>
        /// Invocado cuando una cosa es seleccionada en la interfaz de UcuLife.
        /// </summary>
        /// <param name="thingName">el nombre de la cosa</param>
        void ThingSelected(String thingName);        
    }
}
