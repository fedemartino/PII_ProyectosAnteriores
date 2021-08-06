using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib.Listener
{
    public interface IRemoveListener : IListener
    {
        /// <summary>
        /// Invocado cuando se selecciona la opcion de 'eliminar' en la interfaz
        /// de UcuLife.
        /// </summary>        
        void RemoveClicked();

    }
}
