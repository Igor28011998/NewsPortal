using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsPortal.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Remove(Guid id);
        Task<User> Get(Expression<Func<User, bool>> expression);
    }
}
