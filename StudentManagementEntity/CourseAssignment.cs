using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class CourseAssignment
    {
  
        public int DepartmentId { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public string Code { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public Department Department { get; set; }
    }
}
