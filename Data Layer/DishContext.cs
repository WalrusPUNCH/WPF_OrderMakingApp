using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data_Layer.Entities;
using Data_Layer.Interfaces;

namespace Data_Layer
{
    public class DishContext : DbContext, IDishContext
    {
        public DishContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<DishEntity> Dishes { get; set; }
    }
}
