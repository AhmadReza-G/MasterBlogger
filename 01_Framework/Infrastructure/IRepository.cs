using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure;
public interface IRepository<TKey, T> where T : DomainBase<TKey>
{
    void Create(T entitiy);
    T? GetBy(TKey id);
    List<T> GetAll();
    bool IsExists(Expression<Func<T, bool>> expression);
}
