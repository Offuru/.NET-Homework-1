using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Services;
using Project.Database.Dtos.Request;

namespace Project.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private UsersServices UsersService { get; set; }

        public UsersController(UsersServices usersServices) 
        {
            UsersService = usersServices;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody ]AddUserRequest payload)
        {
            UsersService.AddUser(payload);
            return Ok("User has been succesfully created");
        }

        [HttpGet]
        [Route("{userId}/get-details")]
        public IActionResult GetUserDetails([FromRoute] int userId)
        {
            var result = UsersService.GetUserDetails(userId);

            return Ok(result);
        }
    }
}
