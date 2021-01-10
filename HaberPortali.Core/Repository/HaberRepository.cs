using HaberPortali.Core.Infrastructure;
using HaberPortali.Data.DataContext;
using HaberPortali.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations; //update kısmı icin
namespace HaberPortali.Core.Repository
{
    public class HaberRepository : IHaberRepository
    //once using ekledik sonra implement ettik
    {
        //veritabanımızı cagııryoz
        private readonly HaberContext _context = new HaberContext();
        public int Count()
        {
            //throw new NotImplementedException();
            return _context.Haber.Count();
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            var Haber = GetById(id);
            if(Haber!=null)
            {
                _context.Haber.Remove(Haber);
            }
        }

        public Haber Get(Expression<Func<Haber, bool>> expression)
        {
            //throw new NotImplementedException();
            //burayıda yorum yapıyoruz
            return _context.Haber.FirstOrDefault(expression);
        }

        public IEnumerable<Data.Model.Haber> GetAll()
        {
            //throw new NotImplementedException();
            //bu kısmı yorum yaptık
            return _context.Haber.Select(x => x); //tum haberleri donderecek
        }

        public Haber GetById(int id)
        {
            //throw new NotImplementedException();
            //burayı da yorum yaparak haber id ye gore cekecez
            return _context.Haber.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Haber> GetMany(Expression<Func<Haber, bool>> expression)
        {
            //throw new NotImplementedException();
            return _context.Haber.Where(expression);
        }

        public void Insert(Haber obj)
        {
            //throw new NotImplementedException();
            _context.Haber.Add(obj);
        }

        public void Save()
        {
            //throw new NotImplementedException();
            _context.SaveChanges();
        }

        public void Update(Haber obj)
        {
            //throw new NotImplementedException();
            _context.Haber.AddOrUpdate();
        }
    }
}
