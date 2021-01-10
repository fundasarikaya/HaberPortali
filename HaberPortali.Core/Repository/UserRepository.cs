using HaberPortali.Core.Infrastructure;
using HaberPortali.Data.DataContext;
using HaberPortali.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
namespace HaberPortali.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HaberContext _context = new HaberContext();

        public int Count()
        {
            return _context.User.Count();
        }

        public void Delete(int id)
        {
            var User = GetById(id);
            if (User != null)
            {
                _context.User.Remove(User);
            }
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.User.FirstOrDefault(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.Select(x => x);
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<User> GetMany(Expression<Func<User, bool>> expression)
        {
            return _context.User.Where(expression);
        }

        public void Insert(User obj)
        {
            _context.User.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.User.AddOrUpdate();
        }
    }
}
