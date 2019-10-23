using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Threading;

namespace MediaDeviceApp.Mvvm
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private delegate void NotifyPropertyChangedDeleagte(string propertyName);

        public virtual void NotifyPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (GetType().GetProperty(propertyName) == null)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyName), "No property with name " + propertyName + " exists.");
            }

            if (Dispatcher.CurrentDispatcher.CheckAccess())
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.DataBind, new NotifyPropertyChangedDeleagte(NotifyPropertyChanged), propertyName);
            }
        }

        public virtual void NotifyPropertyChanged()
        {
            string propertyName = new StackFrame(1).GetMethod().Name;

            if (Dispatcher.CurrentDispatcher.CheckAccess())
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.DataBind, new NotifyPropertyChangedDeleagte(NotifyPropertyChanged), propertyName);
            }
        }

        public void NotifyAllPropertiesChanged()
        {
            if (Dispatcher.CurrentDispatcher.CheckAccess())
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
            else
            {
                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.DataBind, new NotifyPropertyChangedDeleagte(NotifyPropertyChanged), null);
            }
        }

        #endregion
    }
}
