using Microsoft.EntityFrameworkCore;
using PayrollAPI.Models;

namespace PayrollAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}

         public DbSet<User> Users { get; set; }
          public DbSet<Company> Companies { get; set; }
         public DbSet<Compensation> Compensations { get; set; }
         public DbSet<Deduction> Deductions { get; set; }
         public DbSet<Employee> Employees { get; set; }
          public DbSet<EcompDeduct> EcompDeducts { get; set; }
    }
}
