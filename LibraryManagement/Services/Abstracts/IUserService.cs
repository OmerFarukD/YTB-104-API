using LibraryManagement.Models.Dtos.Users;

namespace LibraryManagement.Services.Abstracts;

public interface IUserService
{
    List<UserResponseDto> GetAll();
    UserResponseDto? GetById(string id);
    UserResponseDto? GetByEmail(string email);
    void Add(UserAddRequestDto userAddRequestDto);
    
}