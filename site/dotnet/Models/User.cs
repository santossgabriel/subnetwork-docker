namespace Site.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User WithoutPassword() => new User { Id = this.Id, Name = this.Name, Email = this.Email };
  }
}