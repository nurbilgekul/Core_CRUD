using Core_CRUD.Models.Entities.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core_CRUD.Infrastructure.Repositories.Interface
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        IEnumerable<object> Categories { get; }

        List<T> Get(Expression<Func<T, bool>> expression);
        T GetById(int id);
        T FirstByDefault(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        void Add(T item);
        void Update(T item);
        void Delete(T item);
        Category GetById(Func<object, bool> p);
    }
}
