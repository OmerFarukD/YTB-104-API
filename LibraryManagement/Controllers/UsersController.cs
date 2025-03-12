using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepository userRepository = new UserRepository();


        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            userRepository.Add(user);
            return Ok("Kullanıcı Eklendi.");
        }
    }
}
