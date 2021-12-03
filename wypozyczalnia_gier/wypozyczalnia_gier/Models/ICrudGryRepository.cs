using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static wypozyczalnia_gier.Models.AplicationDBContext;

namespace wypozyczalnia_gier.Models
{
    public interface ICrudGryRepository
    {
        Gra Find(int id);
        Gra Delete(int id);
        Gra Add(Gra gra);
        Gra Update(Gra gra);
        
    }

    class CrudGryRepository : ICrudGryRepository
    {
        private ApplicationDbContext _context;
        public CrudGryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Gra Find(int id)
        {
            return _context.Gra.Find(id);
        }

        public Gra Delete(int id)
        {
            var gra = _context.Gra.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return gra;
        }

        public Gra Add(Gra gra)
        {
            var entity = _context.Gra.Update(gra).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Gra Update(Gra gra)
        {
            var entity = _context.Gra.Update(gra).Entity;
            _context.SaveChanges();
            return entity;
        }

        public IList<Gra> FindAll()
        {
            return _context.Gra.ToList();
        }
    }
}
