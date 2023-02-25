using Meetup.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Repository {
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        protected AppContext dbContext;

        public RepositoryBase(AppContext dbContext) {
            this.dbContext = dbContext;
        }

        public RepositoryBase() {

        }
        public T Create(T item) {
            throw new NotImplementedException();
        }

        public T Delete(T item) {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate) {
            throw new NotImplementedException();
        }

        public T Get(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() {
            throw new NotImplementedException();
        }

        public T Update(T item) {
            throw new NotImplementedException();
        }
    }
}
