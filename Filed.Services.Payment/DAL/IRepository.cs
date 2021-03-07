using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.Services.Payment.DAL
{
    public interface IRepository<T> 
        where T : Filed.Services.Payment.DAL.Database.BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
