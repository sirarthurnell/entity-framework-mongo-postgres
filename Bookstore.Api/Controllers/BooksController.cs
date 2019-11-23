using Bookstore.Data.Entities;
using Bookstore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unit;

        public BooksController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IActionResult CreateBookDirectly()
        {
            var newBook = new Book
            {
                Author = "An author",
                BookName = "A book name",
                Category = "A category",
                Price = 5.55M
            };

            _unit.BooksRepository.Create(newBook);
            _unit.Complete();

            return Ok();
        }

        [NonAction]
        public IActionResult CreateBook()
        {
            var newBook = new Book
            {
                Author = "An author",
                BookName = "A book name",
                Category = "A category",
                Price = 5.55M
            };

            _unit.BooksRepository.Create(newBook);
            _unit.Complete();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}