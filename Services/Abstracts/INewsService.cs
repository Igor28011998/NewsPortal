using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortal.Models;

namespace NewsPortal.Services.Abstracts
{
    public interface INewsService
    {
        Task<News> Create(News news);
        Task<News> Update(News news);
        Task<News> Remove(Guid id);
        Task<News> Get(Guid id);
    }
}
