using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Repositories
{
    public class DishRepository : IDishRepository
    {
        private IKitchenContext db;
        public DishRepository(IKitchenContext dishContext)
        {
            db = dishContext;
        }
        public IEnumerable<DishEntity> GetMenu()
        {
            return db.Dishes;
        }
        public DishEntity GetDish(int id)
        {
            return db.Dishes.Find(id);
        }
        public void AddDish(DishEntity dish)
        {
            db.Dishes.Add(dish);
        }
        public void UpdateDish(DishEntity dish)
        {
            DishEntity oldDish = db.Dishes.Where(item => item.ID == dish.ID).FirstOrDefault();

            oldDish.CookingTime = dish.CookingTime;
            oldDish.Cuisine = dish.Cuisine;
            oldDish.Name = dish.Name;
            oldDish.WeightInGrams = dish.WeightInGrams;
        }
        public void DeleteDish(DishEntity dish)
        {
            DishEntity x = db.Dishes.Where( item => item.ID == dish.ID).FirstOrDefault();
                db.Dishes.Remove(x);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
