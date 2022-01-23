using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Models
{
    public interface IGryRepository
    {
        IQueryable<Gra> Gry { get; }
    }

    public interface IKategoriaRepository
    { 
        IQueryable<Kategoria> Kategorie { get; }
    }


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Gra> Gry { get; set; }

        public DbSet<Kategoria> Kategorie { get; set; }
    }

    public class EFGryRepository : IGryRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFGryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Gra> Gry => _applicationDbContext.Gry;

        public IQueryable<Kategoria> Kategorie => _applicationDbContext.Kategorie;
    }
}
