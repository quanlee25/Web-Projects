using Microsoft.EntityFrameworkCore;

namespace Web_Table01.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sach> tSach { get; set; }
    }
}
