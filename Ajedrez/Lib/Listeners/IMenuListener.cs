using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public interface IMenuListener
    {
        /// <summary>
        /// Método que se llama cuando se desea invocar el listener
        /// </summary>
        /// <param name="menuText">Nombre de la opción del menú que fue seleccionada</param>
        void Listen(string menuText);
    }
}
