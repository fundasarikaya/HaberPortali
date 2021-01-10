using HaberPortali.Core.Infrastructure;
using HaberPortali.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using HaberPortali.Data.DataContext;

namespace HaberPortali.Core.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly HaberContext _context = new HaberContext();

        public int Count()
        {
            return _context.Rol.Count();
        }

        public void Delete(int id)
        {
            var Rol = GetById(id);
            if (Rol != null)
            {
                _context.Rol.Remove(Rol);
            }
        }

        public Rol Get(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rol.FirstOrDefault(expression);
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Rol.Select(x => x);
        }

        public Rol GetById(int id)
        {
            return _context.Rol.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rol.Where(expression);
        }

        public void Insert(Rol obj)
        {
            _context.Rol.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Rol obj)
        {
            _context.Resim.AddOrUpdate();
        }
    }
}
