using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface ICookRepository
    {
        IEnumerable<CookEntity> GetCookers(); // получение всех объектов
        CookEntity GetCooker(int id); // получение одного объекта по id
    }
}
