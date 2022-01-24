using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel;

namespace wypozyczalnia_gier.Models
{
    public class Gra
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł!")]
        [DisplayName("Tytuł")]
        public string TytulGry { get; set; }

        public Kategoria KategoriaGry { get; set; }
        [DisplayName("Kategoria")]
        [Required(ErrorMessage = "Wpisz kategorię!")]
        public int KategoriaGryId { get;  set; }

        [DisplayName("Deweloper")]
        [Required(ErrorMessage = "Wpisz dewelopera!")]
        public string DeweloperGry { get; set; }

        [DisplayName("PEGI")]
        [Required(ErrorMessage = "Wpisz PEGI!")]
        public int PEGI { get; set; }

        [DisplayName("Cena")]
        [Required(ErrorMessage = "Wpisz cenę wypożyczenia gry!")]
        public string CenaWypozyczeniaGry { get; set; }

        internal void Patch(Gra gra)
        {
            this.TytulGry = gra.TytulGry;
            this.KategoriaGryId = gra.KategoriaGryId;
            this.DeweloperGry = gra.DeweloperGry;
            this.CenaWypozyczeniaGry = gra.CenaWypozyczeniaGry;
            this.PEGI = gra.PEGI;
        }
    }


   




}
