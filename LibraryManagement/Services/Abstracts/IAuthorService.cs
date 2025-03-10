using LibraryManagement.Models.Dtos.Authors;

namespace LibraryManagement.Services.Abstracts;

public interface IAuthorService
{
    void Add(AuthorAddRequestDto authorAddRequestDto);

    List<AuthorResponseDto> GetAll();

    AuthorResponseDto? GetById(int id);

    void Delete(int id);


}
