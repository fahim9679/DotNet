using CleanStudentManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<QnAs> QnAs { get; set; }
        public DbSet<ExamResults> ExamResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamResults>(entity =>
            {
                entity.HasOne(d => d.Exams)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_ExamResults_Exams");

                entity.HasOne(d => d.QnAs)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(p => p.QnAsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_ExamResults_QnAs");

                entity.HasOne(d => d.Students)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_ExamResults_Students");

            });

            modelBuilder.Entity<Users>().HasData(new Users { Id = 1, Name = "Admin", UserName = "admin", Password = "admin", Role = 1 });
            base.OnModelCreating(modelBuilder);
        }

    }
}
