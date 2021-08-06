using System;
using System.Collections.Generic;
using System.Text;
using Drawing;
using System.Drawing;
using System.Diagnostics;

namespace Obligatorio
{
    /// <summary>
    /// Clase que implementa la interfaz IAction. Se encarga de pintar 
    /// los dibujos en determinado color en el board 
    /// </summary>
    public class Pintar : IAction
    {        
        private Dibujo dibujo;
        private Color color;
        private BoardPainter board;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dibujo">Dibujo a pintar</param>
        /// <param name="color">Color con el cual se deberá pintar el dibujo</param>
        /// <param name="board">Objeto del tipo BoardPainter en el cual se pintará el dibujo</param>
        public Pintar(Dibujo dibujo,Color color,BoardPainter board)
        {
            this.color = color;
            this.dibujo = dibujo;
            this.board = board;
            invariantes();
        }

        /// <summary>
        /// Método que ejecuta la acción de pintar
        /// </summary>
        public void Perform()
        {
            invariantes();
            foreach (IShape figura in dibujo.Componentes)
                board.Paint(figura, color);
            invariantes();
        }

        private void invariantes()
        {
            Debug.Assert(dibujo != null, "El dibujo a pintar no puede ser vacío.");
            Debug.Assert(color != null, "El color elegido para pintar el dibujo no puede ser vacío.");
            Debug.Assert(board != null, "El board donde se pintará el dibujo no puede ser vacío.");
        }
    }
}
