using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollAPI.Helpers;
using PayrollAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PayrollAPI.Data
{
    public class WalletTransactionRepository : IWalletTransactionRepository
    {
        private readonly DataContext _context;
        public WalletTransactionRepository(DataContext context)
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

        
    }
}