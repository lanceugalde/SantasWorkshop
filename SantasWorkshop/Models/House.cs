using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SantasWorkshop.Models
{
    public class House
    {
        [Key]
        public int HouseId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public Boolean HasChimney { get; set; }
    }
}