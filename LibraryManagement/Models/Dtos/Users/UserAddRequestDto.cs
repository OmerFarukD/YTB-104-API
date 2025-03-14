namespace LibraryManagement.Models.Dtos.Users;

public class UserAddRequestDto
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

public class UserResponseDto
{
    public string Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}