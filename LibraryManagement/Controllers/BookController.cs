using LibraryManagement.Exceptions.Types;
using LibraryManagement.Models.Dtos.Books;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{

    // Concretes

    //http://localhost:5078/api/Book/add

    private IBookService bookService;

    public BookController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    // HttpGet : Kaynaktan veri okuma işlemleri için kullanlır.
    // HttpPost : Kaynağa veri ekleme, silme , güncelleme işlemleri için kullanılır.


    [HttpPost("add")]
    public IActionResult Add(BookAddRequestDto  dto)
    {
        try
        {
            bookService.Add(dto);

            return Ok("başarıyla eklendi.");
        }catch(BusinessException ex)
        {
            return BadRequest(ex.Message);
        }catch(ValidationException ex)
        {
            return BadRequest(ex.Message);
        }


    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      
        List<BookResponseDto> books = bookService.GetAll();
        return Ok(books);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        try
        {
            BookResponseDto book = bookService.GetById(id);
            return Ok(book);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

       
    }


}
