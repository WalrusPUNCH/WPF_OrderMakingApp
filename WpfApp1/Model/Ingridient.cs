using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.Model
{
    public class Ingridient
    {
        public string Name { get; private set; } 
        public Ingridient(string name)
        {
            Name = name;
        }
    }
}
