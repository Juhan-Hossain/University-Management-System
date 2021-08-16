using Microsoft.EntityFrameworkCore;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDAL
{
    public class ApplicationDbContext : DbContext
    {
        
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

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
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.HasIndex(x => x.Name).IsUnique();
                entity.HasCheckConstraint("CHK_LengthOfDeptName", "len(name) >= 7");
                entity.Property(x => x.Code).HasMaxLength(7);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.HasCheckConstraint("CHK_LengthOfCode", "len(code) >= 2 and len(code) <= 7");
            });
        }
    }
}