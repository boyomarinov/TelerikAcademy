using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolSystem.Repositories;

namespace SchoolSystem.Services.Tests.Fake
{
    class FakeRepository<T> : IRepository<T> where T:class
    {
      public IList<T> entities = new List<T>();

        public T Add(T entity)
        {
            this.entities.Add(entity);
            return entity;
        }
        public T Get(int id)
        {
            return this.entities[id];
        }

        public IQueryable<T> All()
        {
            return this.entities.AsQueryable();
        }

        public void Update(int id, T entity)
        {
            this.entities[id] = entity;
        }

        public void Delete(int id)
        {
            this.entities.RemoveAt(id);
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            return this.entities.AsQueryable<T>().Where(predicate);
        }
    }
}
