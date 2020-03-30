using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repositories;

namespace Data_Access_Layer
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
