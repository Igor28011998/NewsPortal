using Microsoft.EntityFrameworkCore;
using NewsPortal.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly DbContext _dbContext;

        public NewsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<News> Create(News news)
        {
            _dbContext.Add(news);
            await _dbContext.SaveChangesAsync();

            return news;
        }

        public async Task<News> Update(News news)
        {
            _dbContext.Entry(news).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return news;
        }

        public async Task<News> Remove(Guid id)
        {
            var news = await _dbContext.Set<News>().FindAsync(id);
            if (news == null)
            {
                return news;
            }
            _dbContext.Set<News>().Remove(news);
            await _dbContext.SaveChangesAsync();

            return news;
        }

        public Task<News> Get(Expression<Func<News, bool>> expression)
        {
            return _dbContext.Set<News>().FirstOrDefaultAsync(expression);
        }
    }
}
