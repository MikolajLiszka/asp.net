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

        [Required(ErrorMessage = "Wpisz tytuł!")]
        public string TytulGry { get; set; }
        
        [Required(ErrorMessage = "Wpisz kategorię!")]
        public string KategoriaGry { get; set; }

        [Required(ErrorMessage = "Wpisz dewelopera!")]
        public string DeweloperGry { get; set; }

        [Required(ErrorMessage = "Wpisz PEGI!")]
        public int PEGI { get; set; }

        [Required(ErrorMessage = "Wpisz cenę wypożyczenia gry!")]
        public string CenaWypozyczeniaGry { get; set; }
    }


   




}
