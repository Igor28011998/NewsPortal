using NewsPortal.Models;
using NewsPortal.Repositories.Abstracts;
using NewsPortal.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> Create(User user)
        {
            user.Id = Guid.NewGuid();

            return _repository.Create(user);
        }

        public Task<User> Update(User user)
        {
            return _repository.Update(user);
        }

        public Task<User> Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        public Task<User> Get(Guid id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}