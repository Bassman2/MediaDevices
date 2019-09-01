using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MediaDeviceApp.Mvvm
{
    /*
    public class EventToCommand : DependencyObject
    {
        public static readonly DependencyProperty EventNameProperty = DependencyProperty.RegisterAttached("EventName", typeof(string), typeof(EventToCommand), new PropertyMetadata("", OnEventNameChanged));

        public static string GetEventName(DependencyObject o)
        {
            return (string)o.GetValue(EventNameProperty);
        }

        public static void SetEventName(DependencyObject o, string value)
        {
            o.SetValue(EventNameProperty, value);
        }

        private static void OnEventNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            //FrameworkElement fe = o as FrameworkElement;
            FrameworkElement parent = LogicalTreeHelper.GetParent(o) as FrameworkElement;
            if (parent != null)
            {
                string eventName = GetEventName(o);
                EventInfo info = parent.GetType().GetEvent(eventName);

                Delegate handler = Delegate.CreateDelegate(tDelegate, this, miHandler);


                info.AddEventHandler(parent, handler);

                Type handlerType = info.EventHandlerType;
                MethodInfo invokeMethod = handlerType.GetMethod("Invoke");
                ParameterInfo[] parms = invokeMethod.GetParameters();
                Type[] parmTypes = new Type[parms.Length];
                for (int i = 0; i < parms.Length; i++)
                {
                    parmTypes[i] = parms[i].ParameterType;
                }

            }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(EventToCommand), new PropertyMetadata(null, OnCommandChanged));

        public static ICommand GetCommand(DependencyObject o)
        {
            return (ICommand)o.GetValue(EventNameProperty);
        }

        public static void SetCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(EventNameProperty, value);
        }

        private static void OnCommandChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }*/
}
