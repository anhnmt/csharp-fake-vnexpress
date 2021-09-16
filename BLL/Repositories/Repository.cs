using DAL.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        public IEnumerable<T> GetAll()
        {

            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var data = table.Find(id);
            table.Remove(data);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
