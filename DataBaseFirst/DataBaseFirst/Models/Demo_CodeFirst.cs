using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Models
{
    public class Demo_CodeFirst : DbContext
    {
        public Demo_CodeFirst(DbContextOptions<Demo_CodeFirst> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
