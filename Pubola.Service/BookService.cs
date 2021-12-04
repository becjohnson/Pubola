using Pubola.Data;
using Pubola.Model.Book;
using Pubola.Model.Genre;
using Pubola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Services
{
    public class BookService
    {
        private readonly Guid _userId;
        public BookService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Author = model.Author,
                    Isbn = model.Isbn,
                    CountryCode = model.CountryCode,
                    ReadingLevel = model.ReadingLevel,
                    GenreId = model.GenreId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new BookListItem
                            {
                                Id = e.Id,
                                Title = e.Title,
                                Author = e.Author,
                                GenreId = e.GenreId
                            }
                        );
                return query.ToArray();
            }
        }
        public BookDetail GetBookbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreId = entity.GenreId,
                    };
            }
        }
        public BookDetail GetBookbyTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Title.Contains(title) && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreId = entity.GenreId
                    };
            }
        }
        public BookDetail GetBookbyAuthor(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Author.Contains(author) && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                    };
            }
        }
        public BookDetail GetBookbyIsbn(long isbn)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Isbn == isbn && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreId = entity.GenreId
                    };
            }
        }
        public BookDetail GetBookbyCountryCode(int countryCode)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.CountryCode == countryCode && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreId = entity.GenreId
                    };
            }
        }
        public BookDetail GetBookbyReadingLevel(int readingLevel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.ReadingLevel == readingLevel && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreId = entity.GenreId
                    };
            }
        }
        public BookDetail GetBookbyGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.GenreId == genreId && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreId = entity.GenreId
                    };
            }
        }
            public BookDetail GetBookbyGenreId(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.GenreId == genreId && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                    };
            }
        }
        public bool UpdateBooks(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.Author = model.Author;
                entity.Isbn = model.Isbn;
                entity.CountryCode = model.CountryCode;
                entity.GenreId = model.GenreId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == noteId && e.UserId == _userId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
