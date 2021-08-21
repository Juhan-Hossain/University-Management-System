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
           /* CourseTeacher = new HashSet<Teacher>();*/
            RoomAllocationList = new HashSet<RoomAllocation>();
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

 
        public int? SemesterId { get; set; }


/*        [ForeignKey("Department")]*/
        public int? DepartmentId { get; set; }

        public virtual String AssignTo { get; set; }


        /*public virtual ICollection<Teacher> CourseTeacher { get; set; }*/

        public virtual ICollection<RoomAllocation> RoomAllocationList { get; set; }

    }
}
