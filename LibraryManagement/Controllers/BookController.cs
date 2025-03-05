using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{

    // Concretes

    //http://localhost:5078/api/Book/add

   IBookRepository bookRepository = new BookRepository();

    // HttpGet : Kaynaktan veri okuma işlemleri için kullanlır.
    // HttpPost : Kaynağa veri ekleme, silme , güncelleme işlemleri için kullanılır.


    [HttpPost("add")]
    public IActionResult Add(Book book)
    {
        // INSERT INTO BOOKS() VALUES();

        bookRepository.Add(book);

        return Ok("başarıyla eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        // SELECT * FROM Books

        List<Book> books = bookRepository.GetAll();

        return Ok(books);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        // Select * from Books where Id = 1

        //Book book = context.Books.FirstOrDefault(x=>x.Id == id);

        // Book book = context.Books.Find(text);

        Book book = bookRepository.GetById(id);



       // Book book = context.Books.Where(x => x.Id == id).SingleOrDefault();
        return Ok(book);
    }


}
