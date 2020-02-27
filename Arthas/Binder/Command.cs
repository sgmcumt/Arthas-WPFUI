using System;

namespace Arthas.Binder
{
    public class Command<T> : CommandBase
    {
        readonly Action<T> action;
        readonly Func<T, bool> canAction;

        public Command(Action<T> action, Func<T, bool> canAction = null)
        {
            this.action = action;
            this.canAction = canAction;
        }

        public override bool CanExecute(object parameter)
        {
            if (canAction == null)
                return true;
            if (!(parameter is T value))
                return false;
            return canAction(value);
        }

        public override void Execute(object parameter)
        {
            if (!(parameter is T value))
                return;
            action?.Invoke(value);
        }
    }
}