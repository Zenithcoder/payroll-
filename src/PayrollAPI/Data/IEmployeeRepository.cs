using System.Threading.Tasks;
using PayrollAPI.Models;

namespace PayrollAPI.Data
{
    public interface IEmployeeRepository
    {
          void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
          Task<Employee> GetEmployee(int id);
         Task<bool> SaveAll();    
    }
}