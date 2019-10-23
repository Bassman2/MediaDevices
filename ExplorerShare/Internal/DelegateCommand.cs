using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExplorerCtrl.Internal
{
    /// <summary>
    /// This class allows delegating the commanding logic to methods passed as parameters,
    /// and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
    internal class DelegateCommand : ICommand
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
        /// Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(object param)
        {
            return this.canExecute();
        }

        /// <summary>
        /// Execution of the command
        /// </summary>
        public void Execute(object param)
        {
            this.execute();
        }
       
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

    /// <summary>
    /// This class allows delegating the commanding logic to methods passed as parameters,
    /// and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
    /// <typeparam name="T">Type of the parameter passed to the delegates</typeparam>
    internal class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        /// <summary>
        /// Constructor
        /// </summary>
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecuteMethod = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute ?? new Func<T, bool>(t => true);
        }

        /// <summary>
        /// Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return this.canExecute((T)parameter);
        }

        /// <summary>
        /// Execution of the command
        /// </summary>
        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

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
