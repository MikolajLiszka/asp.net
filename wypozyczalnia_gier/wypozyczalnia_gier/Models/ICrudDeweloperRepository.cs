using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Models
{
    public interface ICrudDeweloperRepository
    {
        Deweloper Find(int id);
        Deweloper Delete(int id);
        Deweloper Add(Deweloper deweloper);
        Deweloper Update(Deweloper deweloper);

        IList<Deweloper> FindAll();
    }

    class CrudDeweloperRepository : ICrudDeweloperRepository
    {
        private ApplicationDbContext _context;
        public CrudDeweloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Deweloper Find(int id)
        {
            return _context.Deweloperzy.Find(id);
        }

        public Deweloper Delete(int id)
        {
            var deweloper = _context.Deweloperzy.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return deweloper;
        }

        public Deweloper Add(Deweloper deweloper)
        {
            var entity = _context.Deweloperzy.Add(deweloper).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Deweloper Update(Deweloper deweloper)
        {
            var entity = _context.Deweloperzy.Update(deweloper).Entity;
            _context.SaveChanges();
            return entity;
        }

        public IList<Deweloper> FindAll()
        {
            return _context.Deweloperzy.ToList();
        }


    }
}
