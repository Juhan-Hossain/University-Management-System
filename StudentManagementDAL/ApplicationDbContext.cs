using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentManagementDAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly DbContextOptions options;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            this.options = options;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        

        public DbSet<CourseAssignment> CourseAssignments { get; set; }




        public DbSet<RoomAllocationList> RoomAllocationLists { get; set; }
        public DbSet<CourseEnroll> CourseEnrolls { get; set; }

        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
        public DbSet<DeletedCourseAssign> DeletedCourseAssigns { get; set; }

        public DbSet<WeekDay> weekDays { get; set; }
        public DbSet<DeletedRoomAllocation> DeletedRoomAllocations { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BS-161\\SQLEXPRESS;"+"Initial Catalog=StudentManagementRuetLatest;"+"Integrated Security=True;"+ "MultipleActiveResultSets = True;"); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Day:
            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.HasData(
                    new WeekDay { Id = 1, DayName = "Sat" },
                    new WeekDay { Id = 2, DayName = "Sun" },
                    new WeekDay { Id = 3, DayName = "Mon" },
                    new WeekDay { Id = 4, DayName = "Tue" },
                    new WeekDay { Id = 5, DayName = "Wed" },
                    new WeekDay { Id = 6, DayName = "Thu" },
                    new WeekDay { Id = 7, DayName = "Fri" }
                    );
            });


            ///RoomAllocation
            modelBuilder.Entity<RoomAllocationList>(entity =>
            {
                entity.HasOne(x => x.Room)
                .WithMany(x => x.RoomAllocationLists).HasForeignKey(x => x.RoomId);
                entity.HasOne(x => x.WeekDay)
                .WithMany(x => x.RoomAllocationLists).HasForeignKey(x => x.DayId);

                entity.HasOne(x => x.Course)
                .WithMany(x => x.RoomAllocationLists).HasForeignKey(x => x.CourseId);

            });




            //StudentResuult:
            modelBuilder.Entity<StudentResult>(entity =>
            {
                entity.HasIndex(x => new { x.CourseName, x.StudentRegNo }).IsUnique();
                /*entity.HasOne(x => x.StudentGrade).WithMany(x=> new)*/


            });

            //CourseAssignment:
            modelBuilder.Entity<CourseAssignment>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            /*modelBuilder.Entity<DeletedCourseAssign>(entity =>
            {
                entity.HasNoKey();
            });*/


            //Student
            modelBuilder.Entity<Student>(entity =>
            {

                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasIndex(x => x.ContactNumber).IsUnique();
                entity.HasIndex(x => x.RegistrationNumber).IsUnique();
                entity.HasMany(x => x.Courses)
                .WithMany(x => x.Students);



            });


            //CourseEnrollment:
            modelBuilder.Entity<CourseEnroll>(entity =>
            {
                entity.HasOne(x => x.Student)
                .WithMany(x => x.CourseEnrolls).HasForeignKey(x => x.EnrolledStudentId);
                entity.HasOne(x => x.Course)
                .WithMany(x => x.CourseEnrolls).HasForeignKey(x => x.EnrolledCourseId);
            });


            //Department

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(x => x.Name).IsUnique();


                entity.HasIndex(x => x.Code).IsUnique();
            });


           

            //Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(x => x.Department).WithMany(x => x.Courses);
   /*             entity.HasOne(x => x.Teacher).WithMany(x => x.Courses);*/


                entity.Property(x => x.Name).IsRequired();
                entity.HasIndex(x => x.Name).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(9);
                entity.HasIndex(x => x.Code).IsUnique();
                /*entity.HasKey(x => new { x.Code, x.DepartmentId }); *///setting code & departmentId as composite key
                entity.HasCheckConstraint("CHK_LengthOfCodeOfCourse", "LEN(Code) >= 5");
                entity.HasCheckConstraint("CHK_CreditRangeOfCourse", "Credit BETWEEN 0.5 AND 5.0");
               
            });

            //Teacher
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(x => x.Name).IsRequired();
                entity.HasIndex(x => x.Name).IsUnique();
                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasOne(a => a.Department).WithMany(b => b.Teachers);
                entity.HasCheckConstraint("CHK_CreditToBeTakenByTeacher", "CreditToBeTaken >= 0");
               
            });

            //Semester
            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasIndex(x => x.Id);
                entity.HasIndex(x => x.Name);
               
            });

            


            ///Room
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });




            //Student Grade:
            modelBuilder.Entity<StudentGrade>(entity =>
            {
            });



        }
    }
}