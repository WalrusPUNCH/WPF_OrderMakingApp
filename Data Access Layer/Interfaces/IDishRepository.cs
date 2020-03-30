using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface IDishRepository
    {
        IEnumerable<DishEntity> GetMenu(); // получение всех объектов
        DishEntity GetDish(int id); // получение одного объекта по id
        void AddDish(DishEntity dish); // создание объекта
        void UpdateDish(DishEntity dish);
        void DeleteDish(DishEntity dish); // удаление объекта по id
    }
}
