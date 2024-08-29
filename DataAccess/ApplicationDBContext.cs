using Microsoft.EntityFrameworkCore;
using Restrunant.Model;

namespace Restrunant.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Category{ get; set; }
        public DbSet<BackUpCatagory> BackCatagory{ get; set; }
    }
}
