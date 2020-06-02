namespace Site.Models
{
  public class UserModel : BaseEntity
  {
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public UserModel WithoutPassword() => new UserModel { Id = this.Id, Name = this.Name, Email = this.Email };

    public override string EntityName => "USER";
  }
}