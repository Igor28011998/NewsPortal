using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewsPortal.Models;

namespace NewsPortal.Repositories.Abstracts
{
    public interface INewsRepository
    {
        Task<News> Create(News news);
        Task<News> Update(News news);
        Task<News> Remove(Guid id);
        Task<News> Get(Expression<Func<News, bool>> expression);
    }
}
