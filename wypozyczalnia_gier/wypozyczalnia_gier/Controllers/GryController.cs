using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;
using wypozyczalnia_gier.Controllers;

namespace wypozyczalnia_gier.Controllers
{
    public class GryController : Controller
    {

        static List<Gra> gryLista = new List<Gra>()
        {
            new Gra(){Id= counter++, TytulGry = "Diablo III", KategoriaGry = "RPG", DeweloperGry = "Blizzard Entertainment", PEGI = 16, CenaWypozyczeniaGry = "10 złotych"},
            new Gra(){Id= counter++, TytulGry = "Cyberpunk 2077", KategoriaGry = "Akcja", DeweloperGry = "CD Projekt Red", PEGI = 18, CenaWypozyczeniaGry = "10 złotych"},
            new Gra(){Id= counter++, TytulGry = "Wiedźmin III : Dziki Gon", KategoriaGry = "Akcja", DeweloperGry = "CD Projekt Red", PEGI = 18, CenaWypozyczeniaGry = "10 złotych"}
        };
        static int counter = 0;

        public IActionResult ListaGier()
        {
            return View("GraDodana", gryLista);
        }

        public IActionResult Edit(int Id)
        {
            Gra gra = gryLista.Find(s => s.Id == Id);
            foreach (var game in gryLista)
            {
                if (game.Id == Id)
                {
                    gra = game;
                    break;
                }
            }
            return View("EditForm", gra);
        }

        [HttpPost]
        public IActionResult Edit(Gra gra)
        {
            int id = gra.Id;
            Gra graFromSerwer = gryLista.Find(s => s.Id == id);
            if (ModelState.IsValid)
            {
                graFromSerwer.TytulGry = gra.TytulGry;
                graFromSerwer.KategoriaGry = gra.KategoriaGry;
                graFromSerwer.DeweloperGry = gra.DeweloperGry;
                graFromSerwer.PEGI = gra.PEGI;
                graFromSerwer.CenaWypozyczeniaGry = gra.CenaWypozyczeniaGry;
                return View("GraDodana", gryLista);
            }
            else
            {
                return View("GraDodana", graFromSerwer);
            }
        }
        public IActionResult Delete(int Id)
        {
            Gra graFromSerwer = gryLista.Find(s => s.Id == Id);
            gryLista.Remove(graFromSerwer);
            return View("GraDodana", gryLista);
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
                counter++;
                gra.Id = counter;
                gryLista.Add(gra);
                return View("GraDodana", gryLista);
            }
            else
            {
                return View("AddForm");
            }
        }

        private IGryRepository repository;
        public GryController(IGryRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult GryRepository()
        {
            return View(repository.Gry);
        }
    }
}
