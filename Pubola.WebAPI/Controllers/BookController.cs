using Microsoft.AspNet.Identity;
using Pubola.Model.Book;
using Pubola.Model.Genre;
using Pubola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubola.WebAPI.Controllers.BookController
{
    [Authorize]
    public class BookController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }
        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateBookService();
            if (!service.CreateBook(book))
            {
                return InternalServerError();
            }
            return Ok("Book was added!");
        }
        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService(userId);
            return bookService;
        }
        public IHttpActionResult GetById(int id)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyId(id);
            return Ok(book);
        }
        public IHttpActionResult GetByTitle(string title)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyTitle(title);
            return Ok(book);
        }
        public IHttpActionResult GetByAuthor(string author)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyAuthor(author);
            return Ok(book);
        }
        public IHttpActionResult GetByGenreId(int genreId)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyGenreId(genreId);
            return Ok(book);
        }
        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateBookService();
            if (!service.UpdateBooks(book))
            {
                return InternalServerError();
            }
            return Ok($"{book.Title} has been updated!");
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateBookService();
            if (!service.DeleteBook(id))
            {
                return InternalServerError();
            }
            return Ok("Book has been deleted!");
        }
    }
}
