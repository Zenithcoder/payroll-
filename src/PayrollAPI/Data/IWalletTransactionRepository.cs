using System.Threading.Tasks;
using PayrollAPI.Models;

namespace PayrollAPI.Data
{
    public interface IWalletTransactionRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();    
    }
}