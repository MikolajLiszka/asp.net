using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Controllers
{
    public class DeweloperzyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaDeweloperow()
        {
            return View("ListaDeweloperowView", repository.FindAll());
        }

        public IActionResult Edit(int Id)
        {
            Deweloper deweloper = repository.Find(Id);

            return View("DeweloperEditView", deweloper);
        }

        [HttpPost]
        public IActionResult Edit(Deweloper deweloper)
        {
            repository.Update(deweloper);

            return View("ListaDeweloperowView", repository.FindAll());
        }

        public IActionResult Details(int Id)
        {
            Deweloper deweloper = repository.Find(Id);

            return View("DeweloperDetailsView", deweloper);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return View("DeweloperDetailsView", repository.FindAll());
        }
       

        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);

            return View("ListaDeweloperowView", repository.FindAll());
        }

        

        public IActionResult Add()
        {
            return View("DeweloperAddView");
        }
        [HttpPost]
        public IActionResult Add(Deweloper deweloper)
        {
            if (ModelState.IsValid)
            {
                repository.Add(deweloper);

                return View("ListaDeweloperowView", repository.FindAll());
            }
            else
            {
                return View("DeweloperAddForm");
            }
        }
        

        private ICrudDeweloperRepository repository;
        public DeweloperzyController(ICrudDeweloperRepository repository)
        {
            this.repository = repository;
        }
    }
}
