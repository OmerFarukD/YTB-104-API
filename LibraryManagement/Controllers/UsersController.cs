using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Users;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        

        [HttpPost("add")]
        public IActionResult Add(UserAddRequestDto user)
        {
            
            _userService.Add(user);
            return Ok("Kullanıcı Eklendi.");
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {

            UserResponseDto userResponseDto = _userService.GetById(id);
            return Ok(userResponseDto);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<UserResponseDto> users = _userService.GetAll();

            return Ok(users);
        }
    }
}
