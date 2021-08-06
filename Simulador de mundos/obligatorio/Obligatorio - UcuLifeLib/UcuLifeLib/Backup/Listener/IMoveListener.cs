using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib.Listener
{
    public interface IMoveListener : IListener
    {
        /// <summary>
        /// Invocado cuando se selecciona la opcion de 'mover' en la interfaz
        /// de UcuLife.
        /// </summary>        
        void MoveClicked();
    }
}
