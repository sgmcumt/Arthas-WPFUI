using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Arthas.Binder
{
    public abstract class Model : INotifyPropertyChanged
    {
        readonly Dictionary<string, object> values = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected T GetValue<T>(Func<T> defValue = null, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                return default;

            if (!values.ContainsKey(propertyName))
                values[propertyName] = defValue == null ? default : defValue();

            return (T)values[propertyName];
        }

        protected bool SetValue<T>(T value, Action callBack = null, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                return false;

            if (values.ContainsKey(propertyName) && Equals(values[propertyName], value))
                return false;
            values[propertyName] = value;
            callBack?.Invoke();
            OnChanged(propertyName);

            return true;
        }
    }
}