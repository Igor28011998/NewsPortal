using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;
using NewsPortal.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsPortal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Remove(Guid id)
        {
            var user = await _dbContext.Set<User>().FindAsync(id);
            if (user == null)
            {
                return user;
            }
            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task<User> Get(Expression<Func<User, bool>> expression)
        {
            return _dbContext.Set<User>().FirstOrDefaultAsync(expression);
        }
    }
}
