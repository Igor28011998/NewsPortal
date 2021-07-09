using NewsPortal.Models;
using NewsPortal.Repositories.Abstracts;
using NewsPortal.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }

        public Task<News> Create(News news)
        {
            news.Id = Guid.NewGuid();

            return _repository.Create(news);
        }

        public Task<News> Update(News news)
        {
            return _repository.Update(news);
        }

        public Task<News> Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        public Task<News> Get(Guid id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}