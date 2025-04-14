using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IInMemoryRepository<T> where T : IdObject
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Guid id);
    }
}
