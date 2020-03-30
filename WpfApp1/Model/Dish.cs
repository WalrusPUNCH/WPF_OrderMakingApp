using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_OrderMakingApp.Model
{
    public class Dish : INotifyPropertyChanged
    {
        //public static int counter = 0;
        //private int id;
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
        [JsonProperty]
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
        [JsonProperty]
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

        /*private List<Ingridient> ingridients;
        public List<Ingridient> Ingridients
        {
            get => ingridients;
            set
            {
                ingridients = value;
                OnPropertyChanged();
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Dish(string name, Specialization spec, TimeSpan cookingTime, float weight /*, List<Ingridient> ingridients*/) : this()
        {
            Name = name;
            Cuisine = spec;
            CookingTime = cookingTime;
            WeightInGrams = weight;
            //Ingridients = ingridients;
        }
        public Dish()
        {
            ID = Guid.NewGuid().ToString();
        }

    }
}
