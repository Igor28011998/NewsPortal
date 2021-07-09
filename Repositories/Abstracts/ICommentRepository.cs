using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsPortal.Repositories.Abstracts
{
    public interface ICommentRepository
    {
        Task<Comment> Create(Comment comment);
        Task<Comment> Update(Comment comment);
        Task<Comment> Remove(Guid id);
        Task<Comment> Get(Expression<Func<Comment, bool>> expression);
    }
}
