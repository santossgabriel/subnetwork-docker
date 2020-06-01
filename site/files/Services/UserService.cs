using System.Linq;
using Site.Models;
using Site.Repository;

namespace Site.Services
{
  public class UserService
  {
    private UserRepository _repository;
    public UserService(UserRepository repository)
    {
      _repository = repository;
    }

    public User Login(string email, string password)
    {
      var user = _repository.FindByEmail(email);
      return user?.Password == password ? user.WithoutPassword() : null;
    }
  }
}