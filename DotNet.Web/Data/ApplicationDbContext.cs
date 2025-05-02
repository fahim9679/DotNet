using DotNet.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<People> Peoples { get; set; } 
    }
}
