using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementEntity
{
    public class DeletedRoomAllocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string CourseCode { get; set; }
        public int DepartmentId { get; set; }

        public int RoomId { get; set; }
     
        public int DayId { get; set; }

        [Display(Name = "Start time (Formate HH:MM) (24 Hours)")]
        public DateTime StartTime { set; get; }

        [Display(Name = "End time (Formate HH:MM) (24 Hours)")]
        public DateTime EndTime { set; get; }
        public string FromMeridiem { get; set; }  //return value AM or PM
        public string ToMeridiem { get; set; } //return value AM or PM

    }
}
