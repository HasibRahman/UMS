using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Name")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Provide Address")]
        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Provide Email Address")]
        [EmailAddress(ErrorMessage = "Please provie a valid email address")]
        [Index("IX_Email",1,IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Remote("IsEmailExist","Teacher",ErrorMessage = "This email is already exist")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Provide Contact Number")]
        [Column(TypeName = "varchar")]
        [StringLength(11)]
        [DisplayName("Contact No.")]
        [RegularExpression("([0-9]+)")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Select a Designation")] 
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Select a Designation")]
        public int DepartmentId { get; set; }

        [Required]
        [Range(0.1,30)]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        [DisplayName("Credit to be Taken")]
        public double TakenCredit { get; set; }

        [Required]
        [DisplayName("Remaining Credit")]
        public double RemainingCredit { get; set; }
        public virtual Department Department { get; set; }
        public  Designation Designation { get; set; }

    }
}