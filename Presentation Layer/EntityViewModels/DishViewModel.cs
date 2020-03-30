using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Business_Logic_Layer.Models;

namespace Presentation_Layer.EntityViewModels
{
    public class DishViewModel : INotifyPropertyChanged
    {       
        private Dish Dish_ = null;

        public string ID
        {
            get => Dish_.ID;
        }
        public string Name
        {
            get => Dish_.Name;
            set { Dish_.Name = value; OnPropertyChanged(); }
        }
        public Specialization Cuisine
        {
            get => Dish_.Cuisine;
            set { Dish_.Cuisine = value; OnPropertyChanged(); }
        }
        public TimeSpan CookingTime
        {
            get => Dish_.CookingTime;
            set { Dish_.CookingTime = value; OnPropertyChanged(); }
        }
        public float WeightInGrams
        {
            get => Dish_.WeightInGrams;
            set
            {
                if (value > 0)
                {
                    Dish_.WeightInGrams = value; OnPropertyChanged();
                }
            }
        }

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

        

        public DishViewModel(Dish dish)
        {
            Dish_ = dish;
            Dish_.PropertyChanged += new PropertyChangedEventHandler(Dish_PropertyChanged);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        void Dish_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged();
        }
        
    }
}
