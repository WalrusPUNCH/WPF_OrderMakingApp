using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Business_Logic_Layer.Models
{
    public class Dish : INotifyPropertyChanged
    {
        public string ID { get; private set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private Specialization cuisine;
        public Specialization Cuisine
        {
            get => cuisine;
            set
            {
                cuisine = value;
                OnPropertyChanged();
            }
        }
        private TimeSpan cookingTime;
        public TimeSpan CookingTime
        {
            get => cookingTime;
            set
            {
                cookingTime = value;
                OnPropertyChanged();
            }
        }
        private float weightInGrams;
        public float WeightInGrams
        {
            get => weightInGrams;
            set
            {
                if (value > 0)
                {
                    weightInGrams = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Dish(string name, Specialization spec, TimeSpan cookingTime, float weight) : this()
        {
            Name = name;
            Cuisine = spec;
            CookingTime = cookingTime;
            WeightInGrams = weight;
        }
        public Dish()
        {
            ID = Guid.NewGuid().ToString();
        }

    }
}
