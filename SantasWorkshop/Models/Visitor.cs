using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }

        public int HouseId { get; set; }
        public virtual House Home { get; set; }

        public int WorkshopId { get; set; }
        public virtual Workshop LastVisited { get; set; }

    }
}