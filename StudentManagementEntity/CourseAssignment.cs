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
        public int Id { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
