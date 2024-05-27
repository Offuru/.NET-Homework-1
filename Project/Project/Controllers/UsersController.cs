using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Services;
using Project.Database.Dtos.Request;

namespace Project.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private UsersServices UsersService { get; set; }

        public UsersController(UsersServices usersServices) 
        {
            UsersService = usersServices;
        }

        [HttpPost("/authorize")]
        [AllowAnonymous]
        public IActionResult Register(RegisterRequest payload)
        {
            UsersService.Register(payload);
            return Ok("Registration succesful");
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest payload)
        {
            var jwtToken = UsersService.Login(payload);
            return Ok(new {token = jwtToken});
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public IActionResult Add([FromBody ]AddUserRequest payload)
        {
            UsersService.AddUser(payload);
            return Ok("User has been succesfully created");
        }

        [HttpGet]
        [Route("{userId}/get-details")]
        [Authorize(Roles = ("Admin"))]
        public IActionResult GetUserDetails([FromRoute] int userId)
        {
            var result = UsersService.GetUserDetails(userId);

            return Ok(result);
        }
    }
}
