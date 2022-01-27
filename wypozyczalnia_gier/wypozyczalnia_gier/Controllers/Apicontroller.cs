using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using wypozyczalnia_gier.Models;

namespace wypozyczalnia_gier.Controllers
{
    public class InvalidPEGIValueException : Exception
    {
        public readonly int PEGI;
        
        public InvalidPEGIValueException(int pegi) : base("Invalid PEGI value.")
        {
            this.PEGI = pegi;
        }
    }

    public class PEGIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidPEGIValueException e)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }
    }

    public class BasicAuthFilterAttribute : ActionFilterAttribute
    {
        private readonly string userName;
        private readonly string password;

        public BasicAuthFilterAttribute(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public override void OnActionExecuting(ActionExecutingContext context) 
        {
            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationValues) == false)
                context.Result = new UnauthorizedResult();
            if (authorizationValues.Count == 0)
                context.Result = new UnauthorizedResult();
            var authorize = authorizationValues.ToString();
            if (authorize.StartsWith("Basic ") == false)
                context.Result = new UnauthorizedResult();
            var encodedCredentials = authorize.Substring("Basic ".Length);
            if (Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this.userName}:{this.password}")) != encodedCredentials)
                context.Result = new UnauthorizedResult();
        }
    }

    [ApiController]
    [BasicAuthFilter("geralt", "triss123")]
    [PEGIExceptionFilter]
    [Route("/api/gry")]
    public class ApiController : ControllerBase
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
                if (gra.PEGI > 18)
                    throw new InvalidPEGIValueException(gra.PEGI);

                this.gameRepository.Add(gra);
                gra = this.gameRepository.Find(gra.Id);
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
        public ActionResult UpdateGra(int id, [FromBody] Gra update)
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
