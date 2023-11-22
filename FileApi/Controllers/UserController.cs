using FileApi.Data;
using FileApi.Entities;
using FileApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FileApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContect _userDbContect;
        private readonly IUserService _userService;

        public UserController(UserDbContect userDbContect,IUserService userService) 
        {
            _userDbContect = userDbContect;
            _userService = userService;

        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser([FromForm]User user)
        {
            User user1 = new User()
            {
               
                UserName = user.UserName,
                ImageUrl = await _userService.CreateAvatarAsync(user.Image)
            };
            

            await _userDbContect.AddAsync(user1);
            await _userDbContect.SaveChangesAsync();
            return Ok(user1); ;
        }
    }
}
