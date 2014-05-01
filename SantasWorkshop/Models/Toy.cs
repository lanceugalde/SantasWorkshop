using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SantasWorkshop.Models
{
    public class Toy
    {
        [Key]
        public int ToyId { get; set; }
        public string Name { get; set; }
        public int RecommendedAge { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department MadeIn { get; set; }
    }
}