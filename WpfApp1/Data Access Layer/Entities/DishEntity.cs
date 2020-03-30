using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPF_OrderMakingApp.ADataLayer.Entities
{
    public class DishEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public TimeSpan CookingTime { get; set; }
        public int Cuisine { get; set; }
        public float WeightInGrams { get; set; }
    }
}
