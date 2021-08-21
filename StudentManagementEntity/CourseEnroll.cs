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


        [Required(ErrorMessage = "Course can't be empty")]
        /*[ForeignKey("Course")]*/
        public int CourseId { set; get; }


        [Required(ErrorMessage = "Student can't be empty")]
        /*[ForeignKey("Student")]*/
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
      
        public bool IsEnrolled { get; set; } = false;

      /*  public virtual Student Student {  get; set; }
        public virtual Course Course {  get; set; }*/
        /*public virtual string GradeName { set; get; }*/


    }
}
