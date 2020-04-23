using System.Threading.Tasks;
using PayrollAPI.Models;

namespace PayrollAPI.Data
{
    public interface IPayoutHistoryRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();    
    }
}