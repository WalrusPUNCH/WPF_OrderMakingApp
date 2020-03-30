using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPF_OrderMakingApp.ADataLayer.Entities;
using WPF_OrderMakingApp.ADataLayer.Interfaces;
using WPF_OrderMakingApp.ADataLayer.Repositories;

namespace WPF_OrderMakingApp.ADataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private IKitchenContext db;
        private DishRepository dishRepository;
        private CookRepository cookRepository;

        public UnitOfWork(IKitchenContext context)
        {
            db = context;
        }

        public IDishRepository Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public ICookRepository Cookers
        {
            get
            {
                if (cookRepository == null)
                    cookRepository = new CookRepository(db);
                return cookRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
