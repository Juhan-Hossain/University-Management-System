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
        [Required(ErrorMessage = "There must be a Course Code\nSample: CSE-***")]
        public String Code { get; set; }
        [Required(ErrorMessage = "There must be a Course Name")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Credit Field Must Be Filled")]
        public float Credit { get; set; }
        public String Description { get; set; }

        [ForeignKey("Semester")]
        public int? SemesterId { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }

        public Semester? Semester { get; set; }
        public Department? CourseDepartment { get; set; }
        public Teacher? Teacher { get; set; }

        /*public virtual ICollection<RoomAllocation> RoomAllocations { get; set; }*/




    }
}
