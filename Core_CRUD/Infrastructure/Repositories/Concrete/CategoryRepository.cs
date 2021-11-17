using Core_CRUD.Infrastructure.Context;
using Core_CRUD.Infrastructure.Repositories.Interface;
using Core_CRUD.Models.Entities.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core_CRUD.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository :IBaseRepository<Category>
    {

        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this._db = appDbContext;
        }

        public IEnumerable<object> Categories => throw new NotImplementedException();

        public void Add(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
        }

        public bool Any(Expression<Func<Category, bool>> expression)
        {
            return _db.Categories.Any(expression);
        }

        public void Delete(Category item)
        {
            item.Status = Status.Passive;
            item.DeleteDate = DateTime.Now;
            _db.SaveChanges();
        }

        public Category FirstByDefault(Expression<Func<Category, bool>> expression)
        {
            return _db.Categories.FirstOrDefault(expression);
        }

        public List<Category> Get(Expression<Func<Category, bool>> expression)
        {
            return _db.Categories.Where(expression).ToList();
        }

        public Category GetById(int id)
        {
            return _db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category GetById(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            _db.Entry<Category>(item).State = EntityState.Modified;
            item.Status = Status.Modified;
            item.UpdateDate = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
