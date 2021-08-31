using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace lab1.Commands
{

    /// <summary>
    ///  Класс RelayCommand
    ///  класс для использования команд
    /// </summary>
    class RelayCommand : ICommand
    {
        private Action<object> _execute;  // определяет, может ли команда выполняться
        private Func<object, bool> _canExecute;  // выполняет логику команды

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }
        
        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
