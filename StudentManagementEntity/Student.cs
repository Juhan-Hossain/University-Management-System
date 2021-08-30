using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class Student
    {
        public Student()
        {
            CourseEnrolls = new HashSet<CourseEnroll>();
            Courses = new HashSet<Course>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        /*[DataType(DataType.EmailAddress)]*/
        [EmailAddress(ErrorMessage = "Please Enter Email Address in correct Format.")]

        public string Email { get; set; }
        public DateTime Date { get; set; } = DateTime.Today.Date;
        [DataType(DataType.PhoneNumber)]
        
        public string ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }



        public int DepartmentId { get; set; }

        public virtual string RegistrationNumber { get; set; }

        public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }


    }
}
