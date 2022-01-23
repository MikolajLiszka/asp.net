using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Models
{
    public class Kategoria
    {
        [HiddenInput]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Kategoria gry nie może przekraczać 20 znaków.")]
        public string Nazwa { get; set; }
        

    }
}
