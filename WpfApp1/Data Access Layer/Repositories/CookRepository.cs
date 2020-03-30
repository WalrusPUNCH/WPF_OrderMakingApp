using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.ADataLayer.Interfaces;
using WPF_OrderMakingApp.ADataLayer.Entities;

namespace WPF_OrderMakingApp.ADataLayer.Repositories
{
    public class CookRepository : ICookRepository
    {
        private IKitchenContext db;
        public CookRepository(IKitchenContext context)
        {
            db = context;
        }
        public CookEntity GetCooker(int id)
        {
            return db.Cookers.Find(id);
        }

        public IEnumerable<CookEntity> GetCookers()
        {
            return db.Cookers;
        }
    }
}
