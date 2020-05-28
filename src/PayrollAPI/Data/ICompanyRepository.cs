using System.Collections.Generic;
using System.Threading.Tasks;
using PayrollAPI.Models;

namespace PayrollAPI.Data
{
    public interface ICompanyRepository
    {
          void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<Company> GetCompany(int id);
         Task<Compensation> GetCompensation(int id);
         Task<Deduction> GetDeduction(int id);
        Task<IEnumerable<Employee>> GetCompanyEmployees (int companyid);
        Task<IEnumerable<Employee>> GetActiveCompanyEmployees (int companyid);
        Task<int> GetStaffStrength(int companyid);
        Task<int> GetDisStaffStrength(int companyid);
        
    }
}