using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class StudentResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Student can't be empty")]

        public string StudentRegNo { get; set; }

      
        public string Name { get; set; }

   
        public string Email { get; set; }

        public bool? Result { get; set; } = false;
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "CourseName can't be empty")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "GradeLetter can't be empty")]
        [ForeignKey("StudentGrade")]
        public string GradeLetter { get; set; }
       
     /*   public int StudentGradeId { get; set; }*/
        public StudentGrade StudentGrade { get; set; }
    }
}
