using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        
        [Required(ErrorMessage = "Wpisz poprawną datę!")]
        public DateTime DataStworzeniaGry { get; set; }

        [Required(ErrorMessage = "Wpisz poziom trudności gry!")]
        public string PoziomTrudnosciGry { get; set; }

        [Required(ErrorMessage = "Wpisz cenę wypożyczenia gry!")]
        public string CenaWypozyczeniaGry { get; set; }
    }
}
