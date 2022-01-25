using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;
using wypozyczalnia_gier.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View("ListaGierView", gameRepository.FindAll());
            //return View("GryRepositorium", repository.FindAll());
        }

        public IActionResult Edit(int Id)
        {
            Gra gra = gameRepository.Find(Id);

            //return View("GraEditViewForm", new EditGameViewModel(gra, this.categoryRepository.FindAll()));
            return View("GraEditViewForm", new EditGameViewModel(gra, this.categoryRepository.FindAll(), this.deweloperRepository.FindAll()));
        }

        [HttpPost]
        public IActionResult Edit(Gra gra)
        {
            if (ModelState.IsValid)
            {
                gameRepository.Update(gra);
                return RedirectToAction("ListaGier");
            }
            else
            {
                //return View("GraEditViewForm", new EditGameViewModel(gra, this.categoryRepository.FindAll()));
                return View("GraEditViewForm", new EditGameViewModel(gra, this.categoryRepository.FindAll(), this.deweloperRepository.FindAll()));
            }
        }

        public IActionResult Delete(int Id)
        {
            gameRepository.Delete(Id);

            return View("ListaGierView", gameRepository.FindAll());
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int Id)
        {
            Gra gra = gameRepository.Find(Id);

            return View("GraDetailView", gra);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return View("ListaGierView", gameRepository.FindAll());
        }

        public IActionResult Add()
        {
            return View("GraAddViewForm", new EditGameViewModel(this.categoryRepository.FindAll(), this.deweloperRepository.FindAll()));
            //return View("GraAddViewForm", new EditGameViewModel(this.deweloperRepository.FindAll()));
        }

        [HttpPost]
        public IActionResult Add(Gra gra)
        {
            if (ModelState.IsValid)
            {
                gameRepository.Add(gra);
                return RedirectToAction("ListaGier");
            }
            else
            {
                //return View("GraAddViewForm", new EditGameViewModel(gra, this.categoryRepository.FindAll()));
                return View("GraAddViewForm", new EditGameViewModel(this.categoryRepository.FindAll(), this.deweloperRepository.FindAll()));
            }
        }

        private ICrudGraRepository gameRepository;
        private ICrudKategoriaRepository categoryRepository;
        private ICrudDeweloperRepository deweloperRepository;

        public GryController(ICrudGraRepository repository, ICrudKategoriaRepository categoryRepository, ICrudDeweloperRepository deweloperRepository)
        {
            this.gameRepository = repository;
            this.categoryRepository = categoryRepository;
            this.deweloperRepository = deweloperRepository;
        }
        public ViewResult GryRepository()
        {
            return View(gameRepository.FindAll());
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

    public class EditGameViewModel : Gra
    {
        public readonly SelectList Categories;
        public readonly SelectList Developers;

        public EditGameViewModel(Gra gra, IList<Kategoria> categories, IList<Deweloper> developers) //: this(categories)
        {
            this.Id = gra.Id;
            this.Patch(gra);
        }

        public EditGameViewModel(IList<Kategoria> categories, IList<Deweloper> developers)
        {
            this.Categories = new SelectList(categories, "Id", "Nazwa");
            this.Developers = new SelectList(developers, "Id", "Nazwa");
        }


        public EditGameViewModel(Gra gra, IList<Deweloper> developers) : this(developers)
        {
            this.Id = gra.Id;
            this.Patch(gra);
        }

        public EditGameViewModel(IList<Deweloper> developers)
        {
            this.Developers = new SelectList(developers, "Id", "Nazwa");
        }
    }
}
