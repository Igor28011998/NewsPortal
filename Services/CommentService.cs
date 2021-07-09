using NewsPortal.Models;
using NewsPortal.Repositories.Abstracts;
using NewsPortal.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public Task<Comment> Create(Comment comment)
        {
            comment.Id = Guid.NewGuid();

            return _repository.Create(comment);
        }

        public Task<Comment> Update(Comment comment)
        {
            return _repository.Update(comment);
        }

        public Task<Comment> Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        public Task<Comment> Get(Guid id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}