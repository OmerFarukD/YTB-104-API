using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Authors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{

    private BaseDbContext dbContext = new BaseDbContext();


    [HttpPost("add")]
    public IActionResult Add(AuthorAddRequestDto dto)
    {
        Author author = new Author()
        {
            FirstName = dto.FirstName,
            SurName = dto.SurName,
            BirthDate = dto.BirthDate
        };


        dbContext.Authors.Add(author);
        dbContext.SaveChanges();

        return Ok("Yazar Eklendi.");
    }



    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Author> authors = dbContext.Authors.ToList();

        return Ok(authors);
    }


}
