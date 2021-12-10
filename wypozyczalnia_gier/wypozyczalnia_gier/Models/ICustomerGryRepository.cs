using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Models
{
    public interface ICustomerGryRepository
    {
        IList<Gra> FindByTytul(string namePattern);
        IList<Gra> FindPage(int page, int size);
        Gra FindById(int id);
    }
    class CustomerGryRepository : ICustomerGryRepository
    {

        private ApplicationDbContext context;
        public CustomerGryRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        public IList<Gra> FindByTytul(string namePattern)
        {
            return (from p in context.Gry where p.TytulGry.Contains(namePattern) select p).ToList();
        }
        public IList<Gra> FindPage(int page, int size)
        {
            return (from p in context.Gry select p).OrderBy(p => p.TytulGry).Skip((page - 1)
           * size).Take(size).ToList();
        }
        public Gra FindById(int id)
        {
            return context.Gry.Find(id);
        }
    }
}
