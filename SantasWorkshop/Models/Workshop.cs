using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Workshop
    {
        [Key]
        public int WorkshopId { get; set; }
        public string Name { get; set; }
    }
}