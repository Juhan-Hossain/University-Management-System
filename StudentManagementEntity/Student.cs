using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        /*[DataType(DataType.EmailAddress)]*/
        [EmailAddress(ErrorMessage = "Please Enter Email Address in correct Format.")]
        
        public string Email { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public long ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public Department? Department { get; set; }

        public int DepartmentId { get; set; }

        
        public string RegistrationNumber { get; set; }
    }
}
