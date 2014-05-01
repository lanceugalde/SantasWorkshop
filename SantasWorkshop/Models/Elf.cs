using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Elf
    {
        [Key]
        public int ToyId { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Workplace{ get; set; }
    }
}