using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Semister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; } 
    }
}