﻿using HaberPortali.Core.Infrastructure;
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
    public class KategoriRepository : IKategoriRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int Count()
        {
            //throw new NotImplementedException();
            return _context.Kategori.Count();
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            var Kategori = GetById(id);
            if (Kategori != null)
            {
                _context.Kategori.Remove(Kategori);
            }
        }

        public Kategori Get(Expression<Func<Kategori, bool>> expression)
        {
            //throw new NotImplementedException();
            //burayıda yorum yapıyoruz
            return _context.Kategori.FirstOrDefault(expression);
        }

        public IEnumerable<Data.Model.Kategori> GetAll()
        {
            //throw new NotImplementedException();
            //bu kısmı yorum yaptık
            return _context.Kategori.Select(x => x); //tum haberleri donderecek
        }

        public Kategori GetById(int id)
        {
            //throw new NotImplementedException();
            //burayı da yorum yaparak haber id ye gore cekecez
            return _context.Kategori.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Kategori> GetMany(Expression<Func<Kategori, bool>> expression)
        {
            //throw new NotImplementedException();
            return _context.Kategori.Where(expression);
        }

        public void Insert(Kategori obj)
        {
            //throw new NotImplementedException();
            _context.Kategori.Add(obj);
        }

        public void Save()
        {
            //throw new NotImplementedException();
            _context.SaveChanges();
        }

        public void Update(Kategori obj)
        {
            //throw new NotImplementedException();
            _context.Kategori.AddOrUpdate();
        }
    }
}
