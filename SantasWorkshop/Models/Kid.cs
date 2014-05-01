using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Kid
    {
        [Key]
        public int KidId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool isNaughty { get; set; }
        public DateTime Birthday { get; set; }
        public int HouseId { get; set; }

        public virtual House Home { get; set; }
    }
}