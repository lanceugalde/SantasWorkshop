using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Reindeer
    {
        [Key]
        public int ReindeerId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int WorkshopId { get; set; }


        public virtual Workshop Stable{ get; set; }

    }
}