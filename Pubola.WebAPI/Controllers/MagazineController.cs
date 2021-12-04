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
        public IHttpActionResult Get()
        {
            MagazineService magazineService = CreateMagazineService();
            var magazines = magazineService.GetMagazines();
            return Ok(magazines);
        }
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
        private MagazineService CreateMagazineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var magazineService = new MagazineService(userId);
            return magazineService;
        }
        public IHttpActionResult Get(int id)
        {
            MagazineService magazineService = CreateMagazineService();
            var magazine = magazineService.GetMagazinebyId(id);
            return Ok(magazine);
        }
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
