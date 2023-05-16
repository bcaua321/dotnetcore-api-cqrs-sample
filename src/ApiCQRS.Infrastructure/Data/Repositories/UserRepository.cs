using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRS.Core.UserContext;
using Microsoft.EntityFrameworkCore;

namespace ApiCQRS.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private DataContext _context { get; set; }

        public UserRepository(DataContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> Add(User user)
        {
            var result = await _context.Users.AddAsync(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(User user)
        {
            var result = _context.Users.Remove(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(User user)
        {
            var result = _context.Users.Update(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> FindById(Guid id)
        {
            var result = await _context.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<User>> FindAll(int limit)
        {
            var result =  await _context.Users
            .AsNoTracking()
            .Take(limit)
            .ToListAsync();

            return result;
        }
    }
}