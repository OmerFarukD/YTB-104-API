using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Authors;
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

        DateTime birthDate = new DateTime(dto.BirthYear,dto.BirthMonth,dto.BirthDay);

        Author author = new Author()
        {
            FirstName = dto.FirstName,
            SurName = dto.SurName,
            BirthDate = birthDate
            
        };


        dbContext.Authors.Add(author);
        dbContext.SaveChanges();

        return Ok("Yazar Eklendi.");
    }



    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Author> authors = dbContext.Authors.ToList();

        List<AuthorResponseDto> responses = new List<AuthorResponseDto>();

        foreach(Author author in authors)
        {
            AuthorResponseDto authorResponseDto = new AuthorResponseDto()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                SurName = author.SurName,
                BirthDay = author.BirthDate.Day,
                BirthMonth = author.BirthDate.Month,
                BirthYear = author.BirthDate.Year
            };

            responses.Add(authorResponseDto);

        }


        return Ok(responses);
    }


}
