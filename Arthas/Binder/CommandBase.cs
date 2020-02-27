using System;
using System.Windows.Input;

namespace Arthas.Binder
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void OnChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}