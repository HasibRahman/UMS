using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Course Code")]
        [Column(TypeName = "varchar")]
        [StringLength(10,MinimumLength = 5)]
        [Index("IX_Code", 1, IsUnique = true)]
        [Remote("IsCodeExist", "Course",ErrorMessage = "This code already exist")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Provide Course Name")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        [Index("IX_Name", 1, IsUnique = true)]
        [Remote("IsNameExist", "Course", ErrorMessage = "This name already exist")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide Course Credit")]
        [Range(0.5,5.0)]
        public decimal Credit { get; set; }

        [Required(ErrorMessage = "Provide Course Description")]
        [Column(TypeName = "varchar")]
        [StringLength(300)]      
        public string Description { get; set; }

        [Required(ErrorMessage = "Select Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Select Semister")]
        public int SemisterId { get; set; }

        public int? TeacherId { get; set; }
        //foreign key er jonno public Department department{get;set;} likhi.virtual likhi filter er jonno
        public virtual Department Department { get; set; }
        public virtual Semister Semister { get; set; }
        public Teacher Teacher { get; set; }
    }
}