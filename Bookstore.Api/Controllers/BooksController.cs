using Bookstore.Data.Entities;
using Bookstore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        public IActionResult GetAll()
        {
            var books = _unit.BooksRepository.GetAll();

            return Ok(books.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var book = _unit.BooksRepository.Get(id);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            _unit.BooksRepository.Create(newBook);
            _unit.Complete();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            _unit.BooksRepository.Update(book.Id, book);
            _unit.Complete();
            
            return NoContent();
        }

        public IActionResult Delete(Guid id)
        {
            _unit.BooksRepository.Remove(id);
            _unit.Complete();

            return NoContent();
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}