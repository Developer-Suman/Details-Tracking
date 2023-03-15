using DetailsTracking.Model;
using Microsoft.EntityFrameworkCore;

namespace DetailsTracking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        
    }
}
