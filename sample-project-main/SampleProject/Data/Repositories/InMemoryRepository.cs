using BusinessEntities;
using Common;
using Microsoft.Extensions.Caching.Memory;
using Raven.Abstractions.Data;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class InMemoryRepository<T> : IInMemoryRepository<T> where T : IdObject
    {
        //private readonly IMemoryCache _cache;
        private readonly AppDbContext _appDbContext;
        public InMemoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Delete(T entity)
        {
            _appDbContext.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public T Get(Guid id)
        {
            return _appDbContext.Find<T>(id);
        }

        public void Create(T entity)
        {
            _appDbContext.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _appDbContext.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
