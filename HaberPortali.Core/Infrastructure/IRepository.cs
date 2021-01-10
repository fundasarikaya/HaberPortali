using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortali.Core.Infrastructure
{
   public interface IRepository<T> where T:class
    {
        //tüm datamızı cekecek
        IEnumerable<T> GetAll();
        //tek bir nesne donecek
        T GetById(int id);
        //tek bir expression ceker
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        //global tum projelerimizde kullancagımız seyler
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        int Count();
        void Save();
    }
}
