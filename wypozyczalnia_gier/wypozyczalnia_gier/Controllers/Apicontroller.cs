using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Controllers
{
    [Route("/api/gry")]
    public class ApiController : Controller
    {
        private ICrudGraRepository gameRepository;
        public ApiController(ICrudGraRepository repository)
        {
            this.gameRepository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetGra(int id)
        {
            var gra = this.gameRepository.Find(id);
            if (gra == null)
                return NotFound();
            return Ok(gra);
        }

        [HttpGet]
        public IEnumerable<Gra> GetGras()
        {
            return this.gameRepository.FindAll();
        }

        [HttpPost]
        public ActionResult AddGra([FromBody] Gra gra)
        {
            if (gra != null && ModelState.IsValid)
            {
                this.gameRepository.Add(gra);
                return new CreatedResult($"/api/gry/{gra.Id}", gra);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteGra(int id)
        {

            Gra gra = this.gameRepository.Find(id);
            if (gra != null)
            {
                this.gameRepository.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateGra (int id, [FromBody] Gra update)
        {
            Gra gra = this.gameRepository.Find(id);
            if (gra != null)
            {
                gra.Patch(update);
                this.gameRepository.Update(gra);
                return Ok(gra);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
