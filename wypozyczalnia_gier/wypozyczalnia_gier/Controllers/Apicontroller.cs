/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Controllers
{
    [Route("/api/gryLista")]
    public class Apicontroller : Controller
    {

        private static List<Gra> gryLista = new List<Gra>()
        {
            new Gra(){TytulGry="Wiedzmin", KategoriaGry="RPG", Id=01},
            new Gra(){TytulGry="Wiedzmin", KategoriaGry="RPG", Id=02}
        };

        [HttpGet]
        [Route("{id}")]

        public Gra GetGra(string id)
        {
            return gryLista.Where<Gra>(s => s.Id.Equals(id)).First();
        }

        [HttpGet]
        public List<Gra> GetGras()
        {
            return gryLista;
        }

        [HttpPost]
        public ActionResult AddGra([FromBody] Gra gra)
        {
            if (gra != null)
            {
                if (ModelState.IsValid)
                {
                    gra.Id = 03; //dodac do repo
                    return new CreatedResult($"/api/gryLista/{gra.Id}", gra);
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete]
        [Route("{id)")]
        public ActionResult DeleteGra(string id)
        {
            Gra gra = gryLista.Where<Gra>(s => s.Id.Equals(id)).First();
            if (gra != null)
            {
                gryLista.Remove(gra);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]

        public ActionResult UpdateGra (string id, [FromBody] Gra update)
        {
            Gra gra = gryLista.Where<Gra>(s => s.Id.Equals(id)).First();
            if (update.TytulGry != null)
            {
                gra.TytulGry = update.TytulGry;
            }
            if (update.KategoriaGry != null)
            {
                gra.KategoriaGry = update.KategoriaGry;
            }
            if (update.DeweloperGry != null)
            {
                gra.DeweloperGry = update.DeweloperGry;
            }
            //zapisac w repo poupdate
            return new OkObjectResult(gra);
        }
    }
}*/
