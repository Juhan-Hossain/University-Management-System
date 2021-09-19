using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagementEntity
{
    public class Course
    {
        public Course()
        {
            CourseEnrolls = new HashSet<CourseEnroll>();
            Students = new HashSet<Student>();
            RoomAllocationLists = new HashSet<RoomAllocationList>();
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required(ErrorMessage = "There must be a Course Code\nSample: CSE-***")]
        public String Code { get; set; }
        [Required(ErrorMessage = "There must be a Course Name")]

        public String Name { get; set; }
        [Required(ErrorMessage = "Credit Field Must Be Filled")]
        public float Credit { get; set; }
        public String Description { get; set; }

   /*     [ForeignKey("Semester")]*/
        public int? SemesterId { get; set; }
     /*   public string SemesterName { get; set; }*/

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }


        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public virtual String AssignTo { get; set; }
        public virtual Department Department { get; set; }



/*        public virtual Teacher? Teacher { get; set; }*/

        public virtual ICollection<RoomAllocationList> RoomAllocationLists { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; }

    }
}