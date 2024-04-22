using Microsoft.AspNetCore.Mvc;
using Project.Core.Services;
using Project.Database.Dtos.Request;

namespace Project.Api.Controllers
{
    [Route("api/gundams")]
    public class GundamsController : ControllerBase
    {
        private GundamsServices GundamsServices { get; set; }

        public GundamsController(GundamsServices gundamsServices)
        {
            GundamsServices = gundamsServices;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddGundam([FromBody] AddGundamRequest payload)
        {
            GundamsServices.AddGundam(payload);

            return Ok("Gundam has been succesfully created");
        }
    }
}
