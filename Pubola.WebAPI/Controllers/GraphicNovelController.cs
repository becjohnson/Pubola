using Microsoft.AspNet.Identity;
using Pubola.Model.GraphicNovel;
using Pubola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubola.WebAPI.Controllers.GraphicNovelController
{
    [Authorize]
    public class GraphicNovelController : ApiController
    {
        private GraphicNovelService CreateGraphicNovelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var graphicNovelService = new GraphicNovelService(userId);
            return graphicNovelService;
        }
        [Route("api/GraphicNovel/Create")]
        public IHttpActionResult Post(GraphicNovelCreate graphicNovel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateGraphicNovelService();
            if (!service.CreateGraphicNovel(graphicNovel))
            {
                return InternalServerError();
            }
            return Ok("Graphic novel was added!");
        }
        [Route("api/GraphicNovel/GetAll")]
        public IHttpActionResult Get()
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovels = graphicNovelService.GetGraphicNovels();
            return Ok(graphicNovels);
        }
        [Route("api/GraphicNovel/GetById")]
        public IHttpActionResult Get(int id)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelbyId(id);
            return Ok(graphicNovel);
        }
        [Route("api/GraphicNovel/GetByTitle")]
        public IHttpActionResult GetByTitle(string title)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelbyTitle(title);
            return Ok(graphicNovel);
        }
        [Route("api/GraphicNovel/GetByAuthor")]
        public IHttpActionResult GetByAuthor(string author)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelbyAuthor(author);
            return Ok(graphicNovel);
        }
        [Route("api/GraphicNovel/GetByIsbn")]
        public IHttpActionResult GetByIsbn(int isbn)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelbyIsbn(isbn);
            return Ok(graphicNovel);
        }
        [Route("api/GraphicNovel/GetByGenre")]
        public IHttpActionResult GetByGenre(int genreId)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelbyIsbn(genreId);
            return Ok(graphicNovel);
        }
        [Route("api/GraphicNovel/Update")]
        public IHttpActionResult Put(GraphicNovelEdit graphicNovel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateGraphicNovelService();
            if (!service.UpdateGraphicNovels(graphicNovel))
            {
                return InternalServerError();
            }
            return Ok("Graphic novel was updated!");
        }
        [Route("api/GraphicNovel/Delete")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGraphicNovelService();
            if (!service.DeleteGraphicNovel(id))
            {
                return InternalServerError();
            }
            return Ok("Graphic novel was deleted!");
        }
    }
}
