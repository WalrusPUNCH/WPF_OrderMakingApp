using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        IDishRepository Dishes { get; }
        ICookRepository Cookers { get; }
        void Save();
    }
}
