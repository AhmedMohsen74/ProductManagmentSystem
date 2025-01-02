using Microsoft.EntityFrameworkCore;

namespace ProductsMS.Models.Domain
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opts) : base(opts)
        { 
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
