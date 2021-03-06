using Pubola.Data;
using Pubola.Model.GraphicNovel;
using Pubola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Services
{
    public class GraphicNovelService
    {
        private readonly Guid _userId;
        public GraphicNovelService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGraphicNovel(GraphicNovelCreate model)
        {
            var entity =
                new GraphicNovel()
                {
                    UserId = _userId,
                    Id = model.Id,
                    Title = model.Title,
                    Author = model.Author,
                    Isbn = (int)model.Isbn,
                    Edition = model.Edition,
                    GenreId = model.GenreId,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GraphicNovels.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GraphicNovelListItem> GetGraphicNovels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GraphicNovels
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new GraphicNovelListItem
                            {
                                Id = e.Id,
                                Title = e.Title,
                                Author = e.Author,
                            }
                        );
                return query.ToArray();
            }
        }
        public GraphicNovelDetail GetGraphicNovelbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        Edition = entity.Edition,
                        GenreId = entity.GenreId
                    };
            }
        }
        public GraphicNovelDetail GetGraphicNovelbyTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Title.Contains(title) && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        Edition = entity.Edition,
                        GenreId = entity.GenreId
                    };
            }
        }
        public GraphicNovelDetail GetGraphicNovelbyAuthor(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Author.Contains(author) && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        Edition = entity.Edition,
                        GenreId = entity.GenreId
                    };
            }
        }
        public GraphicNovelDetail GetGraphicNovelbyIsbn(long isbn)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Isbn == isbn && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        Edition = entity.Edition,
                        GenreId = entity.GenreId
                    };
            }
        }
        public GraphicNovelDetail GetGraphicNovelbyEdition(int edition)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Edition == edition && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        Edition = entity.Edition,
                        GenreId = entity.GenreId
                    };
            }
        }
        public GraphicNovelDetail GetGraphicNovelbyGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.GenreId == genreId && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = entity.Author,
                        Isbn = entity.Isbn,
                        Edition = entity.Edition,
                        GenreId = entity.GenreId
                    };
            }
        }
        public bool UpdateGraphicNovels(GraphicNovelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGraphicNovel(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Id == noteId && e.UserId == _userId);
                ctx.GraphicNovels.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
