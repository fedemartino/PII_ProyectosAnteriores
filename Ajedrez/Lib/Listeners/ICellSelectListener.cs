using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public interface ICellSelectListener
    {
        /// <summary>
        /// Método que se llama cuando se desea invocar el listener
        /// </summary>
        /// <param name="selectedCell">Coordenada de la celda seleccionada</param>
        void Listen(Coordenada selectedCell);
    }
}
