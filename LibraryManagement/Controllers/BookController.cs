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

    IBookService bookService = new BookService();

    // HttpGet : Kaynaktan veri okuma işlemleri için kullanlır.
    // HttpPost : Kaynağa veri ekleme, silme , güncelleme işlemleri için kullanılır.


    [HttpPost("add")]
    public IActionResult Add(BookAddRequestDto  dto)
    {

        bookService.Add(dto);

        return Ok("başarıyla eklendi.");
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
        // Select * from Books where Id = 1

        //Book book = context.Books.FirstOrDefault(x=>x.Id == id);

        // Book book = context.Books.Find(text);

        BookResponseDto book = bookService.GetById(id);



       // Book book = context.Books.Where(x => x.Id == id).SingleOrDefault();
        return Ok(book);
    }


}
