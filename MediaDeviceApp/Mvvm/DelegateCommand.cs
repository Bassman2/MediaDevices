using System;
using System.Windows.Input;

namespace MediaDeviceApp.Mvvm
{
    public class DelegateCommand : ICommand
    {
        private readonly Action execute = null;
        private readonly Func<bool> canExecute = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute ?? new Func<bool>(() => true);
        }

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(object param)
        {
            return this.canExecute();
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute(object param)
        {
            this.execute();
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        //protected virtual void OnCanExecuteChanged()
        //{
        //    CommandManagerHelper.CallWeakReferenceHandlers(this.canExecuteChangedHandlers);
        //}


        /// <summary>
        /// ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
