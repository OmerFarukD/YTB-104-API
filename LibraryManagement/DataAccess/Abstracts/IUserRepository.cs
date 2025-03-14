using LibraryManagement.Models;
using MongoDB.Bson;

namespace LibraryManagement.DataAccess.Abstracts;

public interface IUserRepository
{

    void Add(User user);

    List<User> GetAll();

    User GetById(Guid id);

    void Delete(User user);

    User GetByEmail(string email);
}
