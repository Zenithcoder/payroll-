using Microsoft.EntityFrameworkCore;
using PayrollAPI.Models;

namespace PayrollAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}

         public DbSet<User> Users { get; set; }
    }
}
