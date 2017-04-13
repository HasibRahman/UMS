using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationaryManagement.Models
{
    public class Stationary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Purpose { get; set; }
        public int TypeId { get; set; }
    }
}