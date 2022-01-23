using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Models
{
    public interface ICrudKategoriaRepository
    {
        Kategoria Find(int id);
        Kategoria Delete(int id);
        Kategoria Add(Kategoria kategoria);
        Kategoria Update(Kategoria kategoria);
        
        IList<Kategoria> FindAll();
    }

    class CrudKategoriaRepository : ICrudKategoriaRepository
    {
        private ApplicationDbContext _context;
        public CrudKategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Kategoria Find(int id)
        {
            return _context.Kategorie.Find(id);
        }
        public Kategoria Delete(int id)
        {
            var kategorie = _context.Kategorie.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return kategorie;
        }
        public Kategoria Add(Kategoria kategoria)
        {
            var entity = _context.Kategorie.Add(kategoria).Entity;
            _context.SaveChanges();
            return entity;
        }
        public Kategoria Update(Kategoria kategoria)
        {
            var entity = _context.Kategorie.Update(kategoria).Entity;
            _context.SaveChanges();
            return entity;
        }
        public IList<Kategoria> FindAll()
        {
            return _context.Kategorie.ToList();
        }
    }

}

