using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.Model
{
    public interface IChangeable
    {
        void AddDish(Dish newDish);
        void RemoveDish(Dish dish);
        void UpdateDish(Dish dish);
    }

}
