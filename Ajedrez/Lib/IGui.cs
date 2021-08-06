using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public interface IGui
    {
        /// <summary>
        /// Agrega un listener al IGui. Este listener será llamado cada vez que se hace click sobre el menú
        /// </summary>
        /// <param name="listener">Listener que se ejecutará al seleccionar una opción del menú</param>
        void AddMenuListener(IMenuListener listener);
        /// <summary>
        /// Agrega un listener al Gui. Este listener será llamado cada vez que se haga click sobre una celda del IGui
        /// </summary>
        /// <param name="listener">Listener que se ejecutará al seleccionar una celda del tablero</param>
        void AddCellSelectListener(ICellSelectListener listener);
        /// <summary>
        /// Redibuja el IGui
        /// </summary>
        void Draw();
    }
}
