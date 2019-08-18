using System;
using System.Windows.Input;

namespace Rental.WPF.Command
{
    public class Command<T> : ICommand where T : class
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public Command(Action<T> execute)
            : this(execute, null)
        {
        }

        public Command(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute((T) parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T) parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}