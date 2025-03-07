using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Books;
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
    public IActionResult Add(BookAddRequestDto  dto)
    {
        // INSERT INTO BOOKS() VALUES();

        Book book = new Book()
        {
            Title = dto.Title,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId,
            Isbn = dto.Isbn,
            Page = dto.Page,
            Price = dto.Price
        };

        bookRepository.Add(book);

        return Ok("başarıyla eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        // SELECT * FROM Books

        List<Book> books = bookRepository.GetAll();

        List<BookResponseDto> responses = new List<BookResponseDto>();

        foreach (Book book in books)
        {
            BookResponseDto dto = new BookResponseDto()
            {
                AuthorId = book.AuthorId,
                AuthorName = $"{book.Author.FirstName} {book.Author.SurName}",
                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name,
                Id = book.Id,
                Isbn = book.Isbn,
                Page = book.Page,
                Price = book.Price,
                Title = book.Title
            };

            responses.Add(dto);
        }

        return Ok(responses);
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
