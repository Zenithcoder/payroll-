using System.Threading.Tasks;
using PayrollAPI.Models;
using System.Collections.Generic;

namespace PayrollAPI.Data
{
    public interface IPayrollHistoryRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();    
        Task <IEnumerable<PayrollHistory>> GetPayrollHistory(int id);
       
    }
}