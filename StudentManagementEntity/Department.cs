using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field must be filled")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must given an valid Department Code")]
        public string Code { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
