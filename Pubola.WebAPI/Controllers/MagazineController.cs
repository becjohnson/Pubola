using Microsoft.AspNet.Identity;
using Pubola.Model.Magazine;
using Pubola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubola.WebAPI.Controllers.MagazineController
{
    [Authorize]
    public class MagazineController : ApiController
    {
        private MagazineService CreateMagazineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var magazineService = new MagazineService(userId);
            return magazineService;
        }
        [Route("api/Magazine/Create")]
        public IHttpActionResult Post(MagazineCreate magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateMagazineService();
            if (!service.CreateMagazine(magazine))
            {
                return InternalServerError();
            }
            return Ok("Magazine was added!");
        }
        [Route("api/Magazine/GetAll")]
        public IHttpActionResult Get()
        {
            MagazineService magazineService = CreateMagazineService();
            var magazines = magazineService.GetMagazines();
            return Ok(magazines);
        }
        [Route("api/Magazine/GetById")]
        public IHttpActionResult Get(int id)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazinebyId(id);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByTitle")]
        public IHttpActionResult GetByTitle(string title)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazinebyTitle(title);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByVolume")]
        public IHttpActionResult GetByVolume(int volume)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazinebyVolume(volume);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByIssueDate")]
        public IHttpActionResult GetByIssue(int volume)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazinebyVolume(volume);
            return Ok(magazine);
        }
        [Route("api/Magazine/GetByGenre")]
        public IHttpActionResult GetByGenre(int genreId)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazinebyGenre(genreId);
            return Ok(magazine);
        }
        [Route("api/Magazine/Update")]
        public IHttpActionResult Put(MagazineEdit magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateMagazineService();
            if (!service.UpdateMagazines(magazine))
            {
                return InternalServerError();
            }
            return Ok("Magazine was updated!");
        }
        [Route("api/Magazine/Delete")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMagazineService();
            if (!service.DeleteMagazine(id))
            {
                return InternalServerError();
            }
            return Ok("Magazine was deleted!");
        }
    }
}
