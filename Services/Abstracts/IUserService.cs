using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortal.Models;

namespace NewsPortal.Services.Abstracts
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Remove(Guid id);
        Task<User> Get(Guid id);
    }
}
