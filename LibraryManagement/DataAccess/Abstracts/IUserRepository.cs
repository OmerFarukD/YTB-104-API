using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Abstracts;

public interface IUserRepository
{

    void Add(User user);

}
