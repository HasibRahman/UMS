using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationaryManagement.Models
{
    public class viewStationary
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public decimal SPrice { get; set; }
        public string SPurpose { get; set; }
        public int STypeId { get; set; }
        public decimal  TotalPrice{ get; set; }
    }
}