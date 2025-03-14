using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Users;
using LibraryManagement.Services.Abstracts;

namespace LibraryManagement.Services.Concretes;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    
    
    public List<UserResponseDto> GetAll()
    {
        List<User> users = _userRepository.GetAll();
        List<UserResponseDto> responses = ConvertToResponseDtoList(users);

        return responses;
    }

    public UserResponseDto? GetById(string id)
    {
        Guid convertId = new Guid(id);

        User user = _userRepository.GetById(convertId);
        UserResponseDto responses = ConvertToResponseDto(user);
        return responses;
    }

    public UserResponseDto? GetByEmail(string email)
    {
        User user = _userRepository.GetByEmail(email);
        UserResponseDto responses = ConvertToResponseDto(user);
        return responses;
    }

    public void Add(UserAddRequestDto userAddRequestDto)
    {
        User user = ConvertToUser(userAddRequestDto);
        _userRepository.Add(user);
    }

    private User ConvertToUser(UserAddRequestDto dto)
    {
        return new User { Password = dto.Password, UserName = dto.UserName, Email = dto.Email };
    }

    private UserResponseDto ConvertToResponseDto(User user)
    {
        return new UserResponseDto()
        {
            Password = user.Password, UserName = user.UserName, Email = user.Email, Id = user.Id.ToString()
        };
    }

    private List<UserResponseDto> ConvertToResponseDtoList(List<User> users)
    {
        return users.Select(x => ConvertToResponseDto(x)).ToList();
    }
}