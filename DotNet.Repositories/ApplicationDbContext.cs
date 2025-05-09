using DotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Repositories
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Country> Countries { get; set; } 
        public DbSet<State> States { get; set; } 
        public DbSet<City> Cities { get; set; } 
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSkill>()
                .HasKey(x => new { x.StudentId, x.SkillId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
