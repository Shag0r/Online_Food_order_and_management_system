using Microsoft.EntityFrameworkCore;
using Restrunant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restrunant.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }

        //for the backup tables
        public DbSet<BackupDelete> BackupDeletes { get; set; }
        public DbSet<BackupFoodType> BackupFoodType { get; set; }
        
    }
}
