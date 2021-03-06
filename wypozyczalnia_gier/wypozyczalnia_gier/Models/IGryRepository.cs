using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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

    public interface IDeweloperRepository
    { 
        IQueryable<Deweloper> Deweloperzy { get; }
    }


    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Gra> Gry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gra>().Navigation(e => e.KategoriaGry).AutoInclude();
            modelBuilder.Entity<Gra>().Navigation(g => g.DeweloperGry).AutoInclude();
        }

        public DbSet<Kategoria> Kategorie { get; set; }

        public DbSet<Deweloper> Deweloperzy { get; set; }
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

        public IQueryable<Deweloper> Deweloperzy => _applicationDbContext.Deweloperzy;
    }
}
