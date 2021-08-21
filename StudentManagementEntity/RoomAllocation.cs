using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class RoomAllocation
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }


        [Display(Name = "Department")]
      /*  [ForeignKey("Department")]*/
        public int DeptId { get; set; }

        [Display(Name = "Course")]
       /* [ForeignKey("Course")]*/
        public int CourseId { get; set; }

        [Display(Name = "Room No")]
/*        [ForeignKey("Room")]*/
        public int RoomId { get; set; }
        public Day Day { get; set; } //using enum which will store int value to database

        [Required(ErrorMessage = "Start time is required")]
        [Display(Name = "Start time (Formate HH:MM) (24 Hours)")]
        public string StartTime { set; get; }
        [Required(ErrorMessage = "End time is required")]
        [Display(Name = "End time (Formate HH:MM) (24 Hours)")]
        public string EndTime { set; get; }
        public string FromMeridiem { get; set; }  //return value AM or PM
        public string ToMeridiem { get; set; } //return value AM or PM
        
        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }
        public virtual Room Room { get; set; }


    }
    public enum Day
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednessday,
        Thursday,
        Friday
    }

  




}
