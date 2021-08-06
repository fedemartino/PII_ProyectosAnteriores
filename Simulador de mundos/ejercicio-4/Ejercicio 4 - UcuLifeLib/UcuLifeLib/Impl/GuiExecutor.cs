using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace UcuLifeLib
{
    /// <summary>
    /// Es un ejecutor que ejecuta acciones en el hilo de eventos de usuario
    /// de Windows.
    /// </summary>
    /// <remarks>
    /// La clase es interna de este namespace.
    /// </remarks>
    sealed class GuiExecutor: IExecutor
    {
        private readonly Queue actions;
        private readonly Semaphore actionCount = new Semaphore(0, Int32.MaxValue);

        private readonly Int32 delay;
        private readonly Control control;

        private Thread executeThread;

        private Boolean stoped;                
        /// <summary>
        /// Retorna si el ejecutor esta detenido.
        /// </summary>
        public Boolean Stoped
        {
            get
            {
                return stoped || executeThread == null;
            }
        }

        /// <summary>
        /// Crea un nuevo ejecutor que ejecutara las acciones en el hilo de eventos
        /// de usuario del control.
        /// </summary>
        /// <param name="control">El control.</param>
        /// <param name="delay">Un tiempo en milisegundos para esperar entre
        /// la ejecucion de cada accion</param>
        public GuiExecutor(Control control, Int32 delay)
        {
            Debug.Assert(control != null);

            this.actions = new Queue();
            this.control = control;
            this.delay = delay;
            this.stoped = false;
        }
        
        #region IExecutor implementation

        /// <summary>
        /// Agrega una accion al ejecutor.
        /// </summary>
        /// <param name="action">La accion</param>
        public void AddAction(IAction action)
        {
            Debug.Assert(action != null);

            actions.Enqueue(action);
            actionCount.Release();
        }

        /// <summary>
        /// Retorna si la accion fue agregada previamente a este ejecutor.
        /// </summary>
        /// <param name="action">la accion</param>
        /// <returns>verdadero si fue agregada, falso en otro caso</returns>
        public Boolean ContainsAction(IAction action)
        {
            return actions.Contains(action);
        }

        #endregion

        /// <summary>
        /// Ejecuta la aplicacion.
        /// </summary>
        public void Start()
        {
            Debug.Assert(Stoped);
            
            StartThread();
        }

        /// <summary>
        /// Detiene al ejecutor de acciones.
        /// </summary>
        /// <remarks>
        /// El metodo se bloquea hasta que termina de ejecutar la accion actual.
        /// </remarks>
        public void Stop()
        {
            Debug.Assert(!Stoped);

            stoped = true;

            executeThread.Interrupt();
            executeThread.Join();
            executeThread = null;

            Debug.Assert(Stoped);
        }
        
        private void StartThread()
        {
            stoped = false;

            executeThread = new Thread(new ThreadStart(RunActions));
            executeThread.Start();            
        }

        private void RunActions()
        {                       
            while (!stoped)
            {
                try
                {
                    actionCount.WaitOne();
                    Debug.Assert(actions.Count > 0);

                    IAction next = (IAction)actions.Dequeue();
                    Debug.Assert(next != null);

                    // ejecutar la accion en el hilo de eventos de usuario para 
                    // evitar problemas de sincronizacion con manejadores de eventos
                    if (control.InvokeRequired)
                    {
                        control.Invoke(
                            new ExecuteActionDelegate(RunAction), 
                            new Object[] { next });
                    }
                    else
                    {
                        next.Run();
                    }                        

                    if (!next.Done)
                    {
                        actions.Enqueue(next);
                        actionCount.Release();
                    }

                    Thread.Sleep(delay);
                }
                catch (ThreadInterruptedException)
                {
                    // Excepcion esperada al detener el ejecutor.
                }
            }                        
        }

        private delegate void ExecuteActionDelegate(IAction action);
        private void RunAction(IAction action)
        {
            action.Run();
        }
           
    }
}
