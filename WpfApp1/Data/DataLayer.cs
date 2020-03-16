using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WPF_OrderMakingApp.Data
{
    class DataLayer : IDataLayer
    {
        IDeserialize serializer;

        public DataLayer(IDeserialize serializer_)
        {
            this.serializer = serializer_;
        }

        public IEnumerable<T> GetItems<T>()
        {
            Type type = typeof(T);
            string path = ConfigurationSettings.AppSettings[type.Name];
            if (String.IsNullOrEmpty(path))
                throw new Exception("There is no appropriate key in App.config");
            return serializer.Deserialize<T>(path);
        }

        /*
        public List<Cook> GetCooks()
        {
            List<Cook> cooks = new List<Cook>()
            {               
                new Cook(Qualification.Junior, Specialization.European),
                new Cook(Qualification.Middle, Specialization.European),
                new Cook(Qualification.Senior, Specialization.European),

                new Cook(Qualification.Junior, Specialization.American),
                new Cook(Qualification.Senior, Specialization.American),

                new Cook(Qualification.Middle, Specialization.Asian),
                new Cook(Qualification.Senior, Specialization.Asian)
            };

            return cooks;
        }
        public List<Dish> GetMenu()
        {

            List<Dish> dishes = new List<Dish>();
            List<Ingridient> ingridients = new List<Ingridient>() {
                new Ingridient("Dough"),
                new Ingridient("Sauce"),
                new Ingridient("Meat"),
                new Ingridient("Spices")
            };

            dishes.Add(new Dish("Pizza", Specialization.European, new TimeSpan(0, 30, 0), 500, ingridients));

            ingridients = new List<Ingridient>()
            {
                new Ingridient("Dough"),
                new Ingridient("Sauce"),
                new Ingridient("Meat"),
            };

            dishes.Add(new Dish("Pasta", Specialization.European, new TimeSpan(1, 0, 0), 700, ingridients));

            ingridients = new List<Ingridient>()
            {
                new Ingridient("Chicken"),
                new Ingridient("Oil"),
                new Ingridient("Spices")
            };

            dishes.Add(new Dish("Fried Chicken", Specialization.American, new TimeSpan(0, 10, 0), 300, ingridients));

            ingridients = new List<Ingridient>()
            {
                new Ingridient("Vegetables"),
                new Ingridient("Oil"),
                new Ingridient("Spices")
            };

            dishes.Add(new Dish("French Fries", Specialization.American, new TimeSpan(0, 10, 0), 300, ingridients));

            ingridients = new List<Ingridient>()
            {
                new Ingridient("Fish"),
                new Ingridient("Rice")
            };

            dishes.Add(new Dish("Sushi", Specialization.Asian, new TimeSpan(0, 40, 0), 500, ingridients));


            ingridients = new List<Ingridient>()
            {
                new Ingridient("Chicken"),
                new Ingridient("Spices")
            };

            dishes.Add(new Dish("Chicken Curry", Specialization.Asian, new TimeSpan(1, 5, 0), 750, ingridients));

            return dishes;
        }
        */
    }
}
