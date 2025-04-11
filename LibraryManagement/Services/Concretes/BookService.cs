using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Books;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.BusinessRules;
namespace LibraryManagement.Services.Concretes;


public class BookService : IBookService
{
    private IBookRepository bookRepository;
    private BookBusinessRules _businessRules;

    public BookService(IBookRepository bookRepository, BookBusinessRules businessRules)
    {
        this.bookRepository = bookRepository;
        _businessRules = businessRules;
    }

    public void Add(BookAddRequestDto dto)
    {

       // BookValidationRules.BookAddValidator(dto);

        _businessRules.TitleMustBeUnique(dto.Title);
        _businessRules.IsbnMustBeUnique(dto.Isbn);
    

        Book book = ConvertToTable(dto);

        bookRepository.Add(book);

    }

    public void Delete(int id)
    {
        Book book = bookRepository.GetById(id);

        bookRepository.Delete(book);
    }

    public List<BookResponseDto> GetAll()
    {
        List<Book> books = bookRepository.GetAll();

        List<BookResponseDto> responses = ConvertToResponseDtoList(books);
        
        return responses;
    }


    public BookResponseDto? GetById(int id)
    {
        Book? book = bookRepository.GetById(id);

        _businessRules.BookNotFound(book);
      

        BookResponseDto dto = ConvertToResponseDto(book);

        return dto;
    }



    private List<BookResponseDto> ConvertToResponseDtoList(List<Book> books)
    {

        //2. Yöntem
        //List<BookResponseDto> responses = new List<BookResponseDto>();


        //foreach (Book book in books)
        //{
        //    BookResponseDto dto = ConvertToResponseDto(book);
        //    responses.Add(dto);
        //}
        //return responses;

        return books.Select(x => ConvertToResponseDto(x)).ToList();
    }


    private BookResponseDto ConvertToResponseDto(Book book)
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
            Title = book.Title,
            ImageUrl = book.ImageUrl
        };

        return dto;
    }

    private Book ConvertToTable(BookAddRequestDto dto)
    {
        Book book = new Book()
        {
            Title = dto.Title,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId,
            Isbn = dto.Isbn,
            Page = dto.Page,
            Price = dto.Price
        };
        return book;
    }
}
