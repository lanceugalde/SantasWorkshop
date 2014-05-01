using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Present
    {
        [Key]
        public int PresentId { get; set; }

        public int ToyId { get; set; }
        public virtual Toy Contents { get; set; }
        public int WrappingPaperId { get; set; }
        public virtual WrappingPaper Wrapping { get; set; }
        public int KidId { get; set; } 
        public virtual Kid Recipient { get; set; }
    }
}