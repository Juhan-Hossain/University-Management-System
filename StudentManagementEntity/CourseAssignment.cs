using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class CourseAssignment
    {

       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DepartmentId { get; set; }


        public int TeacherId { get; set; }
        [Required]
        public int CourseId { get; set; }

        public bool IsAssigned { get; set; } = false;

        [NotMapped]
        public bool IsValidOperation { get; set; } = false;
        public virtual Teacher Teacher { get; set; }
    }
}