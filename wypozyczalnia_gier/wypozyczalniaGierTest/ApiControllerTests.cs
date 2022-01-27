using wypozyczalnia_gier.Controllers;
using wypozyczalnia_gier.Models;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace wypozyczalniaGierTest
{
    public class ApiControllerTests
    {
        [Fact]
        public void GetGrasTest()
        {
            var repository = new MemoryGryRepository();
            repository.Add(new Gra() { TytulGry = "TEST" });
            repository.Add(new Gra() { TytulGry = "TEST" });
            var controller = new ApiController(repository);
            var games = controller.GetGras();
            Assert.Equal(2, games.Count());
        }

        /*
        [Fact]
        public void DeleteGraTest()
        {
            var repository = new MemoryGryRepository();
            repository.Add(new Gra() { TytulGry = "TEST" });
            repository.Add(new Gra() { TytulGry = "TEST" });
            var controller = new ApiController(repository);
            Microsoft.AspNetCore.Mvc.IActionResult actionResult = controller.DeleteGra(2);
            Assert.IsType<OkResult>(actionResult);
            actionResult = controller.DeleteGra(6);
            Assert.IsType<NotFoundResult>(actionResult);
        }
        */

        [Fact]
        public void AddGraTest()
        {
            var repository = new MemoryGryRepository();
            repository.Add(new Gra() { TytulGry = "TEST" });
            repository.Add(new Gra() { TytulGry = "TEST" });
            ApiController controller = new ApiController(repository);
            Gra newGra = new Gra() { Id = 10, TytulGry = "NEW" };
            ActionResult<Gra> actionResult = controller.AddGra(newGra);
            Assert.Equal("NEW", repository.Find(3).TytulGry);

        }
    }
}