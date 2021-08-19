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
        public RoomAllocation()
        {
            Courses = new HashSet<Course>();
            Departments = new HashSet<Department>();
            Days = new HashSet<Day>();
        }

        public int Id { get; set; }


        public int DepartmentId { set; get; }
       
        public string Code { set; get; }
        

        
        [ForeignKey("Room")]
        public int RoomId { set; get; }
        

        
        [ForeignKey("Day")]
        public int DayId { set; get; }
        
        //format(HH:MM 24 hours)
        [Required(ErrorMessage = "Start time is required")]
        public string StartTime { set; get; }
        [Required(ErrorMessage = "End time is required")]
        public string EndTime { set; get; }



        public virtual Department? Department { set; get; }
        public virtual Course? Course { set; get; }
        public Room? Room { set; get; }
        public Day? Day { set; get; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Day> Days { get; set; }

        public string? ScheduleInfo { get; set; }

    }
}
