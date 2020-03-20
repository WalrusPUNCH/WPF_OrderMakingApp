using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_OrderMakingApp.ViewModel
{
    public class DishViewModel : INotifyPropertyChanged
    {
        public string Name { get; }
        public string Cuisine { get; }
        public TimeSpan CookingTime { get; }
        public float WeightInGrams { get; }

        private bool isOrdered = false;
        public bool IsOrdered
        {
            get => isOrdered;
            set
            {
                isOrdered = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public DishViewModel(string name, string spec, TimeSpan cookingTime, float weight)
        {
            Name = name;
            Cuisine = spec;
            CookingTime = cookingTime;
            WeightInGrams = weight;
        }
    }
}
