using System;
using System.Windows.Input;

namespace GenSci.FM.Core
{
    public class GenSciCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public GenSciCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
