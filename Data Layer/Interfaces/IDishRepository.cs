using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.Entities;

namespace Data_Layer.Interfaces
{
    interface IDishRepository
    {
        IEnumerable<DishEntity> GetMenu(); // получение всех объектов
        DishEntity GetDish(int id); // получение одного объекта по id
        void AddDish(DishEntity dish); // создание объекта
        void UpdateDish(DishEntity dish);
        void DeleteDish(int id); // удаление объекта по id
    }
}
