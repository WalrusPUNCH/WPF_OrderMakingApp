using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

using Data_Layer.Entities;
using Data_Layer.Interfaces;

namespace Data_Layer.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private IDishContext db;
        public MenuRepository(IDishContext dishContext)
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
            //DishEntity OldDish = (DishEntity)(db.Entry(dish).Entity);
            //OldDish.CookingTime = dish.CookingTime;

        }
        public void DeleteDish(int id)
        {
            DishEntity dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }
    }
}
