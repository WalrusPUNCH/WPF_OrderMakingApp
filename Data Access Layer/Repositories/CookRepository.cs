using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Entities;


namespace Data_Access_Layer.Repositories
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
