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
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Room> Rooms { get; set; }


        public DbSet<CourseAssignment> CourseAssignments { get; set; }




        public DbSet<RoomAllocation> RoomAllocations { get; set; }
        public DbSet<CourseEnroll> CourseEnrolls { get; set; }

        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
        public DbSet<DeletedCourseAssign> DeletedCourseAssigns { get; set; }







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BS-161\\SQLEXPRESS;Initial Catalog=StudentManagementRuetLatest;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //StudentResuult:
            modelBuilder.Entity<StudentResult>(entity =>
            {
                entity.HasIndex(x => new { x.CourseName, x.StudentRegNo }).IsUnique();
                /*entity.HasOne(x => x.StudentGrade).WithMany(x=> new)*/


            });

            //CourseAssignment:
            modelBuilder.Entity<CourseAssignment>(entity =>
            {
                entity.HasKey(x => new { x.Code, x.DepartmentId });
            });

            modelBuilder.Entity<DeletedCourseAssign>(entity =>
            {
                entity.HasKey(x => new { x.Code, x.DepartmentId });
            });


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
                entity.HasKey(x => new { x.StudentRegNo, x.CourseCode,x.DepartmentId });
                entity.HasOne(x => x.Student)
                .WithMany(x => x.CourseEnrolls).HasForeignKey(x=>x.EnrolledStudentId);
                entity.HasOne(x => x.Course)
                .WithMany(x => x.CourseEnrolls).HasForeignKey(x=>new { x.CourseCode,x.DepartmentId });
                
            });


            //Department

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(x => x.Id);
               
                entity.HasIndex(x => x.Name).IsUnique();
                
                
                entity.HasIndex(x => x.Code).IsUnique();
                /*entity.HasCheckConstraint("CHK_LengthOfCode", "len(code) >= 2 and len(code) <= 7");*/
                entity.HasData(
                   new Department { Id = 1, Code = "EEE", Name = "Electronics & Electrical Engineering" },
                   new Department { Id = 2, Code = "CSE", Name = "Computer Science & Engineering" },
                   new Department { Id = 3, Code = "CE", Name = "Civil Engineering" },
                   new Department { Id = 4, Code = "ME", Name = "Mechanical Engineering" },
                   new Department { Id = 5, Code = "MTE", Name = "Mechatronics Engineering" },
                   new Department { Id = 6, Code = "IPE", Name = "Industrial Production & Engineering" },
                   new Department { Id = 7, Code = "MME", Name = "Department of Materials and Metallurgical Engineering" }
               );
            });

            //Designation
            /* modelBuilder.Entity<Designation>(entity=>
             {
                 entity.Property(x => x.Name).IsRequired();
                 entity.HasIndex(x => x.Name).IsUnique();
                 *//*entity.HasData(
                     new Designation() { Id=1,Name = "Professor" },
                     new Designation() { Id=2,Name = "asst. Professor" },
                     new Designation() { Id=3,Name = "Lecturer" },
                     new Designation() { Id=4,Name = "Asst Lecturer" }
                     );*//*
             });*/

            //Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(x => x.Department).WithMany(x => x.Courses);
                entity.HasOne(x => x.Teacher).WithMany(x => x.Courses);


                entity.Property(x => x.Name).IsRequired();
                entity.HasIndex(x => x.Name).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(9);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.HasKey(x => new { x.Code, x.DepartmentId }); //setting code & departmentId as composite key
                entity.HasCheckConstraint("CHK_LengthOfCodeOfCourse", "LEN(Code) >= 5");
                entity.HasCheckConstraint("CHK_CreditRangeOfCourse", "Credit BETWEEN 0.5 AND 5.0");
                entity.HasData(
                    new Course() { Code = "CSE-1102", DepartmentId = 2, Name = "C Lab", Credit = 3, Description = "", SemesterId = 1 },
                    new Course() { Code = "CSE-1103", DepartmentId = 2, Name = "C++", Credit = 3, Description = "", SemesterId = 1 },
                    new Course() { Code = "CSE-1104", DepartmentId = 2, Name = "C++ Lab", Credit = 1.5F, Description = "", SemesterId = 1 }

                    );
            });

            //Teacher
            /* modelBuilder.Entity<Teacher>(entity =>
             {

                 entity.Property(x => x.Name).IsRequired();
                 entity.HasIndex(x => x.Name).IsUnique();
                 entity.HasIndex(x => x.Email).IsUnique();
                 *//*entity.HasOne(a => a.Department).WithMany(b => b.Teachers);*//*
                 entity.HasCheckConstraint("CHK_CreditToBeTakenByTeacher", "CreditToBeTaken >= 0");
                 entity.HasCheckConstraint("CHK_RemainingCreditOfTeacher", "RemainingCredit BETWEEN 0 AND CreditTaken");
                 *//*entity.HasData(
                     new Teacher() { Id = 1, Name = "Ezaz Raihan", Address = "fjdsf", Email = "saif@gmail.com", Contact = 123445, DesignationId = 2, CreditToBeTaken = 100, RemainingCredit = 97, DepartmentId = 2 },
                     new Teacher() { Id = 2, Name = "Ashek", Address = "adafsf", Email = "ashek@gmail.com", Contact = 12312445, DesignationId = 1, CreditToBeTaken = 100, RemainingCredit = 70, DepartmentId = 2 }

                     );*//*
             });*/

            //Semester
            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasIndex(x => x.Id);
                entity.HasIndex(x => x.Name);
                entity.HasData(
                    new Semester { Id = 1, Name = "1st" },
                    new Semester { Id = 2, Name = "2nd" },
                    new Semester { Id = 3, Name = "3rd" },
                    new Semester { Id = 4, Name = "4th" },
                    new Semester { Id = 5, Name = "5th" },
                    new Semester { Id = 6, Name = "6th" },
                    new Semester { Id = 7, Name = "7th" },
                    new Semester { Id = 8, Name = "8th" }
                );
            });

            /// Day
            /* modelBuilder.Entity<Day>(entity =>
             {
                 entity.HasIndex(x => x.Name).IsUnique();
                 entity.HasData(
                     new Day() { Id = 1, Name = "Sat" },
                     new Day() { Id = 2, Name = "Sun" },
                     new Day() { Id = 3, Name = "Mon" },
                     new Day() { Id = 4, Name = "Tue" },
                     new Day() { Id = 5, Name = "Wed" },
                     new Day() { Id = 6, Name = "Thu" },
                     new Day() { Id = 7, Name = "Fri" }
                     );
             });*/


            ///Room
            /* modelBuilder.Entity<Room>(entity =>
             {
                 entity.HasIndex(x => x.Name).IsUnique();
                 entity.HasData(
                     new Room() { Id = 1, Name = "A-101" },
                     new Room() { Id = 2, Name = "A-102" },
                     new Room() { Id = 3, Name = "B-101" },
                     new Room() { Id = 4, Name = "B-102" },
                     new Room() { Id = 5, Name = "C-101" },
                     new Room() { Id = 6, Name = "C-102" },
                     new Room() { Id = 7, Name = "D-101" },
                     new Room() { Id = 8, Name = "D-102" }
                     );
             });*/

            ///RoomAllocation
            /*  modelBuilder.Entity<RoomAllocation>(entity =>
              {
                  entity.HasKey(x => new { x.DayId, x.RoomId, x.StartTime, x.EndTime });
                  entity.HasIndex(x => x.ScheduleInfo).IsUnique();
                  entity.HasIndex(p => p.Department)

                        .WithMany(c => c.Products)
                        .HasForeignKey(p => new { p.CategoryId1, p.CategoryId2 });
                  entity.HasData(
                      new Teacher() { Id = 1, Name = "Ezaz Raihan", Address = "fjdsf", Email = "saif@gmail.com", Contact = 123445, DesignationId = 2, CreditTaken = 3, RemainingCredit = 97, DepartmentId = 2 },
                      new Teacher() { Id = 2, Name = "Ashek", Address = "adafsf", Email = "ashek@gmail.com", Contact = 12312445, DesignationId = 1, CreditTaken = 30, RemainingCredit = 70, DepartmentId = 2 }

                      );
              });*/


            //Student Grade:
            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasData(
                       new StudentGrade() { Grade = "A+" },
                       new StudentGrade() { Grade = "A" },
                       new StudentGrade() { Grade = "A-" },
                       new StudentGrade() { Grade = "B+" },
                       new StudentGrade() { Grade = "B" },
                       new StudentGrade() { Grade = "B-" },
                       new StudentGrade() { Grade = "C+" },
                       new StudentGrade() { Grade = "C" },
                       new StudentGrade() { Grade = "C-" },
                       new StudentGrade() { Grade = "D+" },
                       new StudentGrade() { Grade = "D" },
                       new StudentGrade() { Grade = "D-" },
                       new StudentGrade() { Grade = "F" }
                   );
            });

            

        }
    }
}