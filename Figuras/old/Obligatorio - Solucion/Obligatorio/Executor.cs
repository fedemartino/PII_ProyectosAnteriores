using System;
using System.Text;
using Drawing;
using System.Collections;

namespace Obligatorio
{
    public class Executor : IExecutor
    {
        private FormBoard board;
        private ArrayList acciones;

        #region IExecutor Members

        public void AddAction(IAction action)
        {
            acciones.Add(action);
        }

        public void Execute()
        {
            foreach (IAction accion in acciones)
                accion.Perform();
        }

        #endregion
    }
}
