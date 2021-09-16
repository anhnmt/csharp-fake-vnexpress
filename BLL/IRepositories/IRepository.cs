using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        bool CheckDuplicate(Expression<Func<T, bool>> predicate);
        T Get(object id);
        void Add(T e);
        void AddRange(List<T> e);
        void Edit(T e);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}