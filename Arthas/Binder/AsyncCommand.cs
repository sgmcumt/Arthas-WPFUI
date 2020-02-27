using System;
using System.Threading.Tasks;

namespace Arthas.Binder
{
    public class AsyncCommand<T> : CommandBase
    {
        readonly Func<T, Task> action;
        readonly Func<T, bool> canAction;

        bool isExecuting;

        public AsyncCommand(Func<T, Task> action, Func<T, bool> canAction = null)
        {
            this.action = action;
            this.canAction = canAction;
        }

        public override bool CanExecute(object parameter)
        {
            if (isExecuting)
                return false;
            if (canAction == null)
                return true;
            if (!(parameter is T value))
                return false;
            return canAction(value);
        }

        public override async void Execute(object parameter)
        {
            try
            {
                isExecuting = true;
                OnChanged();

                if (!(parameter is T value))
                    return;

                if (action != null)
                    await action(value);
            }
            finally
            {
                isExecuting = false;
                OnChanged();
            }
        }
    }
}