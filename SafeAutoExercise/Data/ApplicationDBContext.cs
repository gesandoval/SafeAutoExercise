using SafeAutoExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt)
         {
            
         }

         public DbSet<Driver> Drivers { get; set; }

         public DbSet<Trip> Trips { get; set; }

    }
}