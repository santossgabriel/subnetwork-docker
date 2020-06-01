using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
  public class ContactModel
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Message { get; set; }

    public bool SendError { get; set; }
  }
}