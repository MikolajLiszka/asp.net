using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace wypozyczalnia_gier.Models
{
    public class Gra
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł gry!")]
        public string TytulGry { get; set; }
        
        [Required(ErrorMessage = "Wpisz kategorię gry!")]
        public string KategoriaGry { get; set; }

        [Required(ErrorMessage = "Wpisz poziom trudności gry!")]
        public string PoziomTrudnosciGry { get; set; }

        [Required(ErrorMessage = "Wpisz cenę wypożyczenia gry!")]
        public string CenaWypozyczeniaGry { get; set; }
    }

    public class IGamesRepository
    {
        IQueryable<Gra> Games { get; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Gra> Games { get; set; }
    }

    public class EFGamesRepository : IGamesRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public EFGamesRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Gra> Games => _applicationDbContext.Games;
    }

}
