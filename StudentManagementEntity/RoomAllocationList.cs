using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class RoomAllocationList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
         public string CourseCode { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("WeekDay")]
        public int DayId { get; set; } 

        [Required(ErrorMessage = "Start time is required")]
        [Display(Name = "Start time (Formate HH:MM) (24 Hours)")]
        public DateTime StartTime { set; get; }
        [Required(ErrorMessage = "End time is required")]
        [Display(Name = "End time (Formate HH:MM) (24 Hours)")]
        public DateTime EndTime { set; get; }
        public string FromMeridiem { get; set; }  //return value AM or PM
        public string ToMeridiem { get; set; } //return value AM or PM


        public virtual Department Department { get; set; }
        public virtual Room Room { get; set; }
        public virtual WeekDay WeekDay { get; set; }
        public virtual Course Course { get; set; }
    }
}
