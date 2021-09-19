using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class CourseEnroll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string StudentRegNo { get; set; }

        public string CourseCode { get; set; }
        [ForeignKey("Course")]
        
        public int? EnrolledCourseId { set; get; }
        [ForeignKey("Student")]
        public int? EnrolledStudentId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime Date { get; set; }
      
        public bool IsEnrolled { get; set; } = false;
        public string Grade { get; set; }


        public virtual Student Student { get; set; }
        public virtual Department Department { get; set; }

        public virtual Course Course { get; set; }



    }
}
