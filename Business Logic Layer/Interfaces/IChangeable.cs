using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Interfaces
{
    public interface IChangeable
    {
        void AddDish(Dish newDish);
        void RemoveDish(Dish dish);
        void UpdateDish(Dish dish);
    }

}
