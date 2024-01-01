using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoEFMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoEFMvc.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<EnrollmentDetail> EnrollmentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course"); // This maps the table name in the DB
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<EnrollmentDetail>().ToView(nameof(EnrollmentDetails)).HasNoKey();
        }
    }
}