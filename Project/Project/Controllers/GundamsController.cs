using Microsoft.AspNetCore.Mvc;
using Project.Core.Services;
using Project.Database.Dtos.Request;
using Microsoft.AspNetCore.Authorization;

namespace Project.Api.Controllers
{
    [Route("api/gundams")]
    [Authorize]
    public class GundamsController : BaseController
    {
        private GundamsServices GundamsServices { get; set; }

        public GundamsController(GundamsServices gundamsServices)
        {
            GundamsServices = gundamsServices;
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public IActionResult AddGundam([FromBody] AddGundamRequest payload)
        {
            GundamsServices.AddGundam(payload);

            return Ok("Gundam has been succesfully created");
        }
    }
}
