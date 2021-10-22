using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Controllers
{
    public class GryController : Controller
    {

        static List<Gra> gryLista = new List<Gra>()
        {
            new Gra(){TytulGry = "Diablo III", KategoriaGry = "rpg", PoziomTrudnosciGry = "średnia", DataStworzeniaGry = DateTime.Parse("2008-10-10"), CenaWypozyczeniaGry = "10 złotych"}
        };
        static int counter = 0;

        public IActionResult ListaGier()
        {
            return View(gryLista);
        }

        public IActionResult Edit(int Id)
        {
            Gra gra = gryLista.Find(s => s.Id == Id);
            foreach(var game in gryLista)
            {
                if(game.Id == Id)
                {
                    gra = game;
                    break;
                }
            }
            return View("EditForm", gra);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View("AddForm");
        }
        [HttpPost]
        public IActionResult Add(Gra gra)
        {
            if (ModelState.IsValid)
            {
                gra.Id = counter++;
                gryLista.Add(gra);
                return View("GraDodana", gryLista);
            }
            else
            {
                return View("AddForm");
            }
        }
    }
}
