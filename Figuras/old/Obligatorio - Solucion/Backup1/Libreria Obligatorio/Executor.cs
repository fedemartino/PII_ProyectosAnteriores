using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Drawing
{
    /// <summary>
    /// Un ejecutor que refresca una pizarra luego de que está cambia 
    /// luego de ejecutar una acción.
    /// </summary>
    /// <remarks>
    /// El ejecutor ejecuta inicia un hilo que ejecuta las acciones una a una
    /// luego de iniciar la aplicación.
    /// </remarks>
    public sealed class Executor: IExecutor
    {
        private readonly IList<IAction> actions = new List<IAction>();

        private readonly FormBoard display;
        private readonly Thread executeThread;

        private Boolean stoped;

        /// <summary>
        /// Crea una nuevo ejecutor que refresca la pizarra luego 
        /// de que está cambia luego de ejecutar una acción.
        /// </summary>
        /// <param name="display">La pizarra.</param>
        public Executor(FormBoard display)
        {
            this.display = display;
            this.executeThread = new Thread(new ThreadStart(ExecuteActions));
        }

        /// <summary>
        /// Encola una acción para ser ejecutada cuando se llame <code>Execute()</code>.
        /// </summary>
        /// <param name="action">la acción a encolar.</param>
        public void AddAction(IAction action)
        {
            Debug.Assert(action != null, "Action must not be null");

            actions.Add(action);
        }

        /// <summary>
        /// Ejecuta las acciones encoladas en el ejecutor.
        /// </summary>
        /// <remarks>
        /// El órden en que se encolaron las acciones es respetado.
        /// </remarks>
        public void Execute()
        {
            display.Load += new System.EventHandler(this.StartExecutionThread);
            display.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StopExecutionThread);


            display.Show();

            Application.Run();
        }

        private void StartExecutionThread(object sender, EventArgs e)
        {
            
            executeThread.Start();
        }

        private void StopExecutionThread(object sender, EventArgs e)
        {
            stoped = true;
            executeThread.Interrupt();            
            executeThread.Join();
        }

        private void ExecuteActions()
        {            
            foreach (IAction action in actions)
            {
                if (stoped)
                {
                    break;
                }
                ExecuteAction(action);                
            }
        }

        private delegate void ExecuteActionDelegate(IAction action);
        private void ExecuteAction(IAction action)
        {            
            if (display.InvokeRequired)
            {
                try
                {
                    action.Perform();
                }
                catch (ThreadInterruptedException)
                {
                    //PASS, interrupted while waiting in action
                }

                display.BeginInvoke(
                    new ExecuteActionDelegate(ExecuteAction), new object[] { action });
                return;
            }   
                   
            if (display.Changed)
            {
                display.Invalidate();
                display.Update();
            }
        }
        
    }
}
