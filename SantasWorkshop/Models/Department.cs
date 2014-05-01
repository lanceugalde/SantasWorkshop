using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ProductionType { get; set; }
        public int WorkshopId { get; set; }

        public virtual Workshop Workshop { get; set; }

    }
}