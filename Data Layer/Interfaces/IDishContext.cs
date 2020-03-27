using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data_Layer.Entities;

namespace Data_Layer.Interfaces
{
    public interface IDishContext
    {
        DbSet<DishEntity> Dishes { get; set; }
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
    }
}
