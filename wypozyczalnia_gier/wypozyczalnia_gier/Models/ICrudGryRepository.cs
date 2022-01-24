using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace wypozyczalnia_gier.Models
{
        public interface ICrudGraRepository
        {
            Gra Find(int id);
            Gra Delete(int id);
            Gra Add(Gra gra);
            Gra Update(Gra gra);
            IList<Gra> FindAll();
        }

        public class CrudGraRepository : ICrudGraRepository
        {
            private ApplicationDbContext _context;
            public CrudGraRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public Gra Find(int id)
            {
                return _context.Gry.Find(id);
            }
            public Gra Delete(int id)
            {
                var gry = _context.Gry.Remove(Find(id)).Entity;
                _context.SaveChanges();
                return gry;
            }
            public Gra Add(Gra gry)
            {
                var entity = _context.Gry.Add(gry).Entity;
                _context.SaveChanges();
                return entity;
            }
            public Gra Update(Gra gry)
            {
                var entity = _context.Gry.Update(gry).Entity;
                _context.SaveChanges();
                return entity;
            }
            public IList<Gra> FindAll()
            {
            return _context.Gry.Include(g => g.KategoriaGry).ToList();
            }
        }
}
