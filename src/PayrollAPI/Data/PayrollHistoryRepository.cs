using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollAPI.Helpers;
using PayrollAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PayrollAPI.Data
{
    public class PayrollHistoryRepository : IPayrollHistoryRepository
    {
        private readonly DataContext _context;
        public PayrollHistoryRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

         public async Task<IEnumerable<PayrollHistory>> GetPayrollHistory (int id)
        {
             var payrollHistories =  await _context.PayrollHistories.Where(e => e.CompanyId == id).ToListAsync();
             return payrollHistories;
        }
        
    }
}