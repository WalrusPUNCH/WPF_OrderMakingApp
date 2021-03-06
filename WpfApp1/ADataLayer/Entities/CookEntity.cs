﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.ADataLayer.Entities
{
    public class CookEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        public int Qualification_ { get; set; }
        public int Specialization_ { get; set; }
        public DateTime EndOfWorkTime { get; set; }
        public List<DishEntity> Queue { get; set; }
    }
}
