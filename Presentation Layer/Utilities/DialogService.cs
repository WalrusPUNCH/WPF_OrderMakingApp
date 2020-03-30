using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation_Layer.Utilities
{
    public class DialogService
    {
        Dictionary<Type, Type> VMToWindowMapper = new Dictionary<Type, Type>();

        public void RegisterType<VM, Win>() where Win : Window, new() where VM : class
        {
            var VM_Type = typeof(VM);
            var Win_Type = typeof(Win);
            VMToWindowMapper[VM_Type] = Win_Type;
        }

        public Window CreateWindow(object vm)
        {
            var VM_Type = vm.GetType();
            var Window_Type = VMToWindowMapper[VM_Type];
            var window = (Window)Activator.CreateInstance(Window_Type);
            window.DataContext = vm;
            return window;
        }
    }
}
