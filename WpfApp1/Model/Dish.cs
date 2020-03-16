﻿using System;
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
        public string Name { get; private set; }
        [JsonProperty]
        public Specialization Cuisine { get; private set; }
        public TimeSpan CookingTime { get; private set; }
        [JsonProperty]
        public float WeightInGrams { get; private set; }
        public List<Ingridient> Ingridients { get; private set; }
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
        public Dish(string name, Specialization spec, TimeSpan cookingTime, float weight, List<Ingridient> ingridients)
        {
            Name = name;
            Cuisine = spec;
            CookingTime = cookingTime;
            WeightInGrams = weight;
            Ingridients = ingridients;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
