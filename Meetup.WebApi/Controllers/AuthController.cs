using AutoMapper;
using Meetup.DAL.Contracts;
using Meetup.DAL.Models;
using Meetup.WebApi.DTO;
using Meetup.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.WebApi.Controllers {
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller {
        UserManager<User> _userManager;
        AuthManager _auth;
        public AuthController(UserManager<User> uManager, AuthManager auth) {
            _userManager = uManager;
            _auth= auth;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegisterDTO user) {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserForRegisterDTO, User>()).CreateMapper();
            var newUser = mapper.Map<User>(user);
            await _userManager.CreateAsync(newUser, user.Password);

            return StatusCode(201, newUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthUserDTO user) {

            if (!await _auth.ValidateUser(user))
                return Unauthorized();

            return Ok(new { Token = await _auth.CreateToken() });
        }
    }
}
