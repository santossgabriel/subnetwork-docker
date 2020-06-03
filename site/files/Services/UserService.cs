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

    public UserModel Login(string email, string password)
    {
      var user = _repository.FindByEmail(email);
      return user?.Password == password ? user.WithoutPassword() : null;
    }

    public void Save(UserModel user)
    {
      var userDB = _repository.FindByEmail(user.Email);
      if (userDB == null)
      {
        _repository.Add(user);
      }
      else
      {
        _repository.Update(user);
      }
    }
  }
}