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
        public IHttpActionResult Get()
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovels = graphicNovelService.GetGraphicNovels();
            return Ok(graphicNovels);
        }
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
        private GraphicNovelService CreateGraphicNovelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var graphicNovelService = new GraphicNovelService(userId);
            return graphicNovelService;
        }
        public IHttpActionResult Get(int id)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelbyId(id);
            return Ok(graphicNovel);
        }
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
