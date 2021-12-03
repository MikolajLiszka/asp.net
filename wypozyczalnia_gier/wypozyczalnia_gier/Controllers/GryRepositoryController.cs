using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wypozyczalnia_gier.Controllers
{
    public class GryRepositoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
