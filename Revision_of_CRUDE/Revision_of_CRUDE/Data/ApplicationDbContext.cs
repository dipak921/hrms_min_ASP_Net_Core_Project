using Microsoft.EntityFrameworkCore;

namespace Revision_of_CRUDE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Revision_of_CRUDE.Models.Student> Students { get; set; }
    }
}
