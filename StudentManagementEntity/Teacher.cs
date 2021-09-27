using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be given")]

        public String Name { get; set; }
        [Required(ErrorMessage = "Address must be given")]
        public String Address { get; set; }
        [Required]
        [EmailAddress]
        //found on stack overflow
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Contact must be given")]
        public long Contact { get; set; }

        /*[Required(ErrorMessage = "Field must be given")]
        [ForeignKey("Designation")]*/
        public int? DesignationId { get; set; }

        [Required(ErrorMessage = "CreditToBeTaken must be given")]

        public double CreditToBeTaken { get; set; } = 100;

        public double RemainingCredit { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual ICollection<Course> Courses { get; set; }


    }
}