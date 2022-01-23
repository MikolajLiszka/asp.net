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
           /* new Gra(){Id= counter++, TytulGry = "Diablo III", KategoriaGry = "RPG", DeweloperGry = "Blizzard Entertainment", PEGI = 16, CenaWypozyczeniaGry = "10 złotych"},
            new Gra(){Id= counter++, TytulGry = "Cyberpunk 2077", KategoriaGry = "Akcja", DeweloperGry = "CD Projekt Red", PEGI = 18, CenaWypozyczeniaGry = "10 złotych"},
            new Gra(){Id= counter++, TytulGry = "Wiedźmin III : Dziki Gon", KategoriaGry = "Akcja", DeweloperGry = "CD Projekt Red", PEGI = 18, CenaWypozyczeniaGry = "10 złotych"}
           */
        };
        //static int counter = 0;

        public IActionResult ListaGier()
        {
            return View("ListaGierView", repository.FindAll());
            //return View("GryRepositorium", repository.FindAll());
        }

        public IActionResult Edit(int Id)
        {
            Gra gra = repository.Find(Id);

            return View("GraEditViewForm", gra);
        }

        [HttpPost]
        public IActionResult Edit(Gra gra)
        {
            repository.Update(gra);

            //int id = gra.Id;
            //Gra graFromSerwer = repository.Find()

            //  gryLista.Find(s => s.Id == id);

            return View("ListaGierView", repository.FindAll());

            /*if (ModelState.IsValid)
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
            }*/
        }
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);

            return View("ListaGierView", repository.FindAll());
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int Id)
        {
            Gra gra = repository.Find(Id);

            return View("GraDetailView", gra);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return View("ListaGierView", repository.FindAll());
        }

        public IActionResult Add()
        {
            return View("GraAddViewForm");
        }
        [HttpPost]
        public IActionResult Add(Gra gra)
        {
            if (ModelState.IsValid)
            {
                repository.Add(gra);

                return View("ListaGierView", repository.FindAll());
            }
            else
            {
                return View("GraAddViewForm");
            }
        }

        private ICrudGraRepository repository;
        public GryController(ICrudGraRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult GryRepository()
        {
            return View(repository.FindAll());
        }
         /*
        private IGryRepository repository;
        public GryController(IGryRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult GryRepository()
        {
            return View(repository.Gry);
        }
        */
        }
}
