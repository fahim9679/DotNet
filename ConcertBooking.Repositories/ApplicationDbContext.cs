
using ConcertBooking.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertBooking.Repositories
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Venue> Venues{ get; set; } 
        public DbSet<Concert> Concerts { get; set; } 
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
