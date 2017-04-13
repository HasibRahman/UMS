using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Department Code")]
        [Column(TypeName = "varchar")]
        [StringLength(7,MinimumLength = 2)]
        [Index("IX_Code", 1, IsUnique = true)]
        [Remote("IsCodeExist","Department",ErrorMessage = "This Code already exist")]        
        public string Code { get; set; }

        [Required(ErrorMessage = "Provide Department Name")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}