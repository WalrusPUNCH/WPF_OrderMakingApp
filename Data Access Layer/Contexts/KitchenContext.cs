using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Contexts
{
    public class KitchenContext : DbContext, IKitchenContext
    {
        public KitchenContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<KitchenContext>(new StoreDbInitializer());
        }

        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<CookEntity> Cookers { get; set; }
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<KitchenContext>
    {
        protected override void Seed(KitchenContext db)
        {

            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 0, Qualification_ = 10, Queue = new List<DishEntity>() });
            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 0, Qualification_ = 15, Queue = new List<DishEntity>() });
            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 0, Qualification_ = 20, Queue = new List<DishEntity>() });
            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 1, Qualification_ = 10, Queue = new List<DishEntity>() });
            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 1, Qualification_ = 20, Queue = new List<DishEntity>() });
            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 2, Qualification_ = 15, Queue = new List<DishEntity>() });
            db.Cookers.Add(new CookEntity() { EndOfWorkTime = DateTime.Now, Specialization_ = 2, Qualification_ = 20, Queue = new List<DishEntity>() });

            db.Dishes.Add(new DishEntity() { Name = "Pizza", Cuisine = 0, CookingTime = new TimeSpan(0, 30, 0), WeightInGrams = 500 });
            db.Dishes.Add(new DishEntity() { Name = "Pasta", Cuisine = 0, CookingTime = new TimeSpan(1, 0, 0), WeightInGrams = 700});
            db.Dishes.Add(new DishEntity() { Name = "Fried Chicken", Cuisine = 1, CookingTime = new TimeSpan(0, 10, 0), WeightInGrams = 300});
            db.Dishes.Add(new DishEntity() { Name = "French Fries", Cuisine = 1, CookingTime = new TimeSpan(0, 10, 0), WeightInGrams = 300});
            db.Dishes.Add(new DishEntity() { Name = "Sushi", Cuisine = 2, CookingTime = new TimeSpan(0, 40, 0), WeightInGrams = 500});
            db.Dishes.Add(new DishEntity() { Name = "Chicken Curry", Cuisine = 2, CookingTime = new TimeSpan(1, 5, 0), WeightInGrams = 750});
            db.SaveChanges();
        }
    }
}
