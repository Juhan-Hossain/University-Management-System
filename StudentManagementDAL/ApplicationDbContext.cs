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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BS-161\\SQLEXPRESS;Initial Catalog=StudentManagementSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //Student
            modelBuilder.Entity<Student>(entity =>
            {

                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasIndex(x => x.ContactNumber).IsUnique();
                entity.HasIndex(x => x.RegistrationNumber).IsUnique();
            });


            //Department

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.HasIndex(x => x.Name).IsUnique();
                entity.HasCheckConstraint("CHK_LengthOfDeptName", "len(name) >= 7");
                entity.Property(x => x.Code).HasMaxLength(5);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.HasCheckConstraint("CHK_LengthOfCode", "len(code) >= 2 and len(code) <= 7");
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
            modelBuilder.Entity<Designation>(entity=>
            {
                entity.Property(x => x.Name).IsRequired();
                entity.HasIndex(x => x.Name).IsUnique();
                entity.HasData(
                    new Designation() { Id=1,Name = "Professor" },
                    new Designation() { Id=2,Name = "asst. Professor" },
                    new Designation() { Id=3,Name = "Lecturer" },
                    new Designation() { Id=4,Name = "Asst Lecturer" }
                    );
            });

            //Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(x => x.CourseDepartment).WithMany(x => x.Courses);
                entity.Property(x => x.Name).IsRequired();
                entity.HasIndex(x => x.Name).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(9);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.HasKey(x => new { x.Code, x.DepartmentId }); //setting code & departmentId as composite key
                entity.HasCheckConstraint("CHK_LengthOfCodeOfCourse", "LEN(Code) >= 5");
                entity.HasCheckConstraint("CHK_CreditRangeOfCourse", "Credit BETWEEN 0.5 AND 5.0");
                /*entity.HasData(
                    new Designation() { Id = 1, Name = "Professor" },
                    new Designation() { Id = 2, Name = "asst. Professor" },
                    new Designation() { Id = 3, Name = "Lecturer" },
                    new Designation() { Id = 4, Name = "Asst Lecturer" }
                    );*/
            });
        }
    }
}