using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Models
{
    public class Deweloper
    {
        [HiddenInput]
        public int Id { get; set; }

        //[StringLength(35, ErrorMessage = "Deweloper gry nie może przekraczać 35 znaków.")]
        public string Nazwa { get; set; }
    }
}
