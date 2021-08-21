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
    /*    [ForeignKey("Department")]*/

        public int? DepartmentId { get; set; }
/*        [ForeignKey("Teacher")]*/

        public int? TeacherId { get; set; }
/*        [ForeignKey("Course")]*/
        public int? CourseId { get; set; }

        public bool IsAssigned { get; set; } = false;



        public string Code { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }
    }
}
