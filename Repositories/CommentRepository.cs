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
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _dbContext;

        public CommentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> Create(Comment comment)
        {
            _dbContext.Add(comment);
            await _dbContext.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment> Update(Comment comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> Remove(Guid id)
        {
            var comment = await _dbContext.Set<Comment>().FindAsync(id);
            if (comment == null)
            {
                return comment;
            }
            _dbContext.Set<Comment>().Remove(comment);
            await _dbContext.SaveChangesAsync();

            return comment;
        }

        public Task<Comment> Get(Expression<Func<Comment, bool>> expression)
        {
            return _dbContext.Set<Comment>().FirstOrDefaultAsync(expression);
        }
    }
}
