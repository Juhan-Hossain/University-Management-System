using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagementEntity
{
    public class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Teachers = new HashSet<Teacher>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field must be filled")]
        [Display(Name = "Department name")]
        [StringLength(255, MinimumLength = 7, ErrorMessage = "Name must be between 7 and 255 character in length.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "You must given an valid Department Code")]
        [Display(Name = "Department Code")]
        [StringLength(7, MinimumLength = 3, ErrorMessage = "Code must be between 3 and 7 character in length.")]

        public string Code { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
