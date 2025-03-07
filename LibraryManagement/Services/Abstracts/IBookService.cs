using LibraryManagement.Models.Dtos.Books;

namespace LibraryManagement.Services.Abstracts;

public interface IBookService
{

    void Add(BookAddRequestDto dto);
    List<BookResponseDto> GetAll();
    BookResponseDto? GetById(int id);

    void Delete(int id);
}
