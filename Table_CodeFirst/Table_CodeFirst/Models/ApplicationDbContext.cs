using Microsoft.EntityFrameworkCore;
namespace Table_CodeFirst.Models
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Nguoi> Nguois { get; set; }
        public DbSet<Cho> Chos { get; set; }
       
    }
}
