using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollAPI.Helpers;
using PayrollAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PayrollAPI.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
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

        public async Task<Company> GetCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(u => u.Id == id);

            return company;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Compensation> GetCompensation(int id)
        {
            var compensation = await _context.Compensations.FirstOrDefaultAsync(u => u.Id == id);

            return compensation;
        }

        public async Task<Deduction> GetDeduction(int id)
        {
            var deduction = await _context.Deductions.FirstOrDefaultAsync(u => u.Id == id);
            return deduction;
        }

        public async Task<IEnumerable<Employee>> GetCompanyEmployees(int companyid)
        {
             var employees =  await _context.Employees.Where(e => e.CompanyId == companyid).ToListAsync();
             return employees;
        }

        public async Task<IEnumerable<Employee>> GetActiveCompanyEmployees(int companyid)
        {
             var employees =  await _context.Employees.Where(e => e.CompanyId == companyid && e.Status == "active").ToListAsync();
             return employees;
        }
    }
}