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

        public int CourseId { get; set; }

        public int IsAssigned { get; set; } = 1;

        [NotMapped]
        public bool IsValidOperation { get; set; } = false;
        [Required]
        public string Code { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }
    }
}
