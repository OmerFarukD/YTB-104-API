using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Authors;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{

    private IAuthorService authorService = new AuthorService();


    [HttpPost("add")]
    public IActionResult Add(AuthorAddRequestDto dto)
    {

        authorService.Add(dto);

        return Ok("Yazar Eklendi.");
    }



    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(authorService.GetAll());
    }


}
