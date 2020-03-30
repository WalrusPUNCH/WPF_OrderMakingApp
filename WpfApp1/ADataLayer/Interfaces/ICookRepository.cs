using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_OrderMakingApp.ADataLayer.Entities;

namespace WPF_OrderMakingApp.ADataLayer.Interfaces
{
    public interface ICookRepository
    {
        IEnumerable<CookEntity> GetCookers(); // получение всех объектов
        CookEntity GetCooker(int id); // получение одного объекта по id
    }
}
