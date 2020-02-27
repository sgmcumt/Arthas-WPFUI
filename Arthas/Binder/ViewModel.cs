using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Arthas.Binder
{
    public abstract class ViewModel : Model
    {
        protected Command<T> GetCommand<T>(Action<T> action, Func<T, bool> canAction = null, [CallerMemberName] string propertyName = null)
        {
            return GetValue(() => new Command<T>(action, canAction), propertyName);
        }

        protected AsyncCommand<T> GetAsyncCommand<T>(Func<T, Task> action, Func<T, bool> canAction = null, [CallerMemberName] string propertyName = null)
        {
            return GetValue(() => new AsyncCommand<T>(action, canAction), propertyName);
        }
    }
}