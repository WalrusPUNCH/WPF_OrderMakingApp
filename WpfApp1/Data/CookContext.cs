using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WPF_OrderMakingApp.Model;

namespace WPF_OrderMakingApp.Data
{
    public class CookContext : DbContext
    {
        public CookContext() : base("DefaultConnection")
        {

        }

        public DbSet<Cook> Cooks { get; set; }
    }
}
