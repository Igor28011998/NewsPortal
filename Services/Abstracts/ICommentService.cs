using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortal.Models;

namespace NewsPortal.Services.Abstracts
{
    public interface ICommentService
    {
        Task<Comment> Create(Comment comment);
        Task<Comment> Update(Comment comment);
        Task<Comment> Remove(Guid id);
        Task<Comment> Get(Guid id);
    }
}
