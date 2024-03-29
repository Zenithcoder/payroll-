using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollAPI.Helpers;
using PayrollAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PayrollAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
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

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u => u.Id == id);

            return employee;
        }
        
    }
}