using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Authors;
using LibraryManagement.Services.Abstracts;

namespace LibraryManagement.Services.Concretes;

public class AuthorService : IAuthorService
{
    private IAuthorRepository authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        this.authorRepository = authorRepository;
    }

    public void Add(AuthorAddRequestDto authorAddRequestDto)
    {

        Author author = ConvertToAuthor(authorAddRequestDto);
        authorRepository.Add(author);
    }

    public void Delete(int id)
    {
        Author author = authorRepository.GetById(id);
        authorRepository.Delete(author);
    }

    public List<AuthorResponseDto> GetAll()
    {
        List<Author> authors = authorRepository.GetAll();
        List<AuthorResponseDto> responses = ConvertToResponseDtoList(authors);
        return responses;
    }

    public AuthorResponseDto? GetById(int id)
    {
        Author author = authorRepository.GetById(id);
        AuthorResponseDto response = ConvertToResponse(author);

        return response;
    }

    private Author ConvertToAuthor(AuthorAddRequestDto dto)
    {
        return new Author {
            FirstName=dto.FirstName,
            SurName = dto.SurName,
            BirthDate = new DateTime(dto.BirthYear,dto.BirthMonth,dto.BirthDay),
        };
    }


    private List<AuthorResponseDto> ConvertToResponseDtoList(List<Author> authors)
    {
        return authors.Select(x=>ConvertToResponse(x)).ToList();
    }


    private AuthorResponseDto ConvertToResponse(Author author)
    {
        return new AuthorResponseDto
        {
            Id = author.Id,
            BirthDay = author.BirthDate.Day,
            BirthMonth =$"{author.BirthDate.Month} -> {GetMonthName(author.BirthDate.Month)}",
            BirthYear = author.BirthDate.Year,
            FirstName = author.FirstName,
            SurName = author.SurName
        };
    }


    private string GetMonthName(int month)
    {
        //if(month == 1)
        //{
        //    return "Ocak";
        //}
        //if(month == 2)
        //{
        //    return "Şubat";
        //}

        return month switch
        {
            1=>"Ocak",
            2=>"Şubat",
            3=>"Mart",
            4=>"Nisan",
            5=>"Mayıs",
            6=>"Haziran",
            7=>"Temmuz",
            8=>"Ağustos",
            9=>"Eylül",
            10=>"Ekim",
            11=> "Kasım",
            12 => "Aralık"
        };
    }
}
