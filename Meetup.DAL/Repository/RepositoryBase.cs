using Meetup.DAL.Contracts;
using Meetup.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Meetup.DAL.Repository {
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        protected repContext dbContext;

        public RepositoryBase(repContext context) {
            this.dbContext = context;
        }

        public void Create(T item) => dbContext.Set<T>().Add(item);

        public void Delete(T item) => dbContext.Set<T>().Remove(item);

        public void Update(T item) => dbContext.Set<T>().Update(item);
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            dbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            dbContext.Set<T>()
            .Where(expression);
        public IQueryable<T> FindAll(bool trackChanges) => 
            !trackChanges ?
            dbContext.Set<T>()
            .AsNoTracking() :
            dbContext.Set<T>();
    }
}
