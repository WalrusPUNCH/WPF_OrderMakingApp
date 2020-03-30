using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using WPF_OrderMakingApp.ADataLayer.Entities;

namespace WPF_OrderMakingApp.ADataLayer.Interfaces
{
    public interface IKitchenContext
    {
        DbSet<DishEntity> Dishes { get; set; }
        DbSet<CookEntity> Cookers { get; set; }
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}
