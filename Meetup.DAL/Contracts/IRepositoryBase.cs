using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Contracts {
    internal interface IRepositoryBase<T> {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T , Boolean> predicate);
        T Get(int id);
        T Create(T item);
        T Update(T item);
        T Delete(T item);
    }
}
