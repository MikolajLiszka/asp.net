using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Controllers
{
    public class KategorieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaKategorii()
        {
            return View("ListaKategoriiView", repository.FindAll());
            //return View("GryRepositorium", repository.FindAll());
        }

        public IActionResult Edit(int Id)
        {
            Kategoria kategoria = repository.Find(Id);

            return View("KategoriaEditView", kategoria);
        }

        [HttpPost]
        public IActionResult Edit(Kategoria kategoria)
        {
            repository.Update(kategoria);

            return View("ListaKategoriiView", repository.FindAll());
        }

        public IActionResult Details(int Id)
        {
            Kategoria kategoria = repository.Find(Id);

            return View("KategoriaDetailsView", kategoria);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return View("KategoriaDetailsView", repository.FindAll());
        }

        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);

            return View("ListaKategoriiView", repository.FindAll());
        }

        public IActionResult Add()
        {
            return View("KategoriaAddView");
        }
        [HttpPost]
        public IActionResult Add(Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                repository.Add(kategoria);

                return View("ListaKategoriiView", repository.FindAll());
            }
            else
            {
                return View("KategoriaAddForm");
            }
        }

        private ICrudKategoriaRepository repository;
        public KategorieController(ICrudKategoriaRepository repository)
        {
            this.repository = repository;
        }


    }
}
