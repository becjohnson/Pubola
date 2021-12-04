using Pubola.Data;
using Pubola.Model.Magazine;
using Pubola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Services
{
    public class MagazineService
    {
        private readonly Guid _userId;
        public MagazineService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMagazine(MagazineCreate model)
        {
            var entity =
                new Magazine()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Volume = model.Volume,
                    IssueDate = model.IssueDate,
                    GenreId = model.GenreId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Magazines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MagazineListItem> GetMagazines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Magazines
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new MagazineListItem
                            {
                                Id = e.Id,
                                Title = e.Title,
                                Volume = e.Volume,
                                IssueDate = e.IssueDate,
                            }
                        );
                return query.ToArray();
            }
        }
        public MagazineDetail GetMagazinebyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new MagazineDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Volume = entity.Volume,
                        IssueDate = entity.IssueDate,
                        GenreId = entity.GenreId,
                    };
            }
        }
        public MagazineDetail GetMagazinebyTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Title == title && e.UserId == _userId);
                return
                    new MagazineDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Volume = entity.Volume,
                        IssueDate = entity.IssueDate,
                        GenreId = entity.GenreId,
                    };
            }
        }
        public bool UpdateMagazines(MagazineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.Volume = model.Volume;
                entity.IssueDate = model.IssueDate;
                entity.GenreId = model.GenreId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMagazine(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == noteId && e.UserId == _userId);
                ctx.Magazines.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
