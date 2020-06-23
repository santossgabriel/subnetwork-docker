using System.ComponentModel.DataAnnotations;
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

    public bool EmailAlreadyExists(string email) => _repository.FindByEmail(email) != null;

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

    public UserModel UpdatePassword(string email, string password)
    {
      var user = _repository.FindByEmail(email);
      if (user == null)
        throw new ValidationException("Email não cadastrado");
      user.Password = password;
      _repository.Update(user);
      return user.WithoutPassword();
    }

    public UserModel UpdateAccount(UserModel model)
    {
      var user = _repository.GetById(model.Id);
      if (user == null)
        throw new ValidationException("Usuário não encontrado.");
      user.Document = model.Document;
      user.Name = model.Name;
      _repository.Update(user);
      return user.WithoutPassword();
    }
  }
}