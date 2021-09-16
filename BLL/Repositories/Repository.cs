using DAL.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using DAL.Common;

namespace BLL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ApplicationDbContext _context = null;
        public DbSet<T> table = null;

        public Repository()
        {
            this._context = new ApplicationDbContext();
            this._context.Configuration.ValidateOnSaveEnabled = false;
            this.table = _context.Set<T>();
        }

        public Repository(ApplicationDbContext _context)
        {
            this._context = _context;
            this.table = _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return table.AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).AsEnumerable();
        }

        public bool CheckDuplicate(Expression<Func<T, bool>> predicate)
        {
            return table.AsNoTracking().Any(predicate);
        }

        public T Get(object id)
        {
            return table.Find(id);
        }

        public void Add(T e)
        {
            table.Add(e);
            _context.SaveChanges();
        }

        public void AddRange(List<T> e)
        {
            table.AddRange(e);
            _context.SaveChanges();
        }

        public void Edit(T e)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var data = table.Find(id);

            if (Utils.IsNullOrEmpty(data)) return;

            table.Remove(data);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
            _context.SaveChanges();
        }
    }
}