using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class WrappingPaper
    {
        [Key]
        public int WrappingPaperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}