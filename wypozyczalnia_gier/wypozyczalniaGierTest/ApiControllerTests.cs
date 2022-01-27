using wypozyczalnia_gier.Controllers;
using wypozyczalnia_gier.Models;
using Xunit;
using System.Linq;

namespace wypozyczalniaGierTest
{
    public class ApiControllerTests
    {
        [Fact]
        public void GetBooksTest()
        {
            var repository = new MemoryGryRepository();
            repository.Add(new Gra() { TytulGry = "TEST" });
            repository.Add(new Gra() { TytulGry = "TEST" });
            var controller = new ApiController(repository);
            var games = controller.GetGras();
            Assert.Equal(2, games.Count());
        }
    }
}