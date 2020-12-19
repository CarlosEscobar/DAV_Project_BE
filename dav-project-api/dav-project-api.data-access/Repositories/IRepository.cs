using System;
using System.Collections.Generic;

namespace dav_project_api.data_access.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
