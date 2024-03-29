using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
  public class Command
  {
    [Key] // nije potrebno
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string HowTo { get; set; }

    [Required]
    public string Line { get; set; }

    [Required]
    public string Platform { get; set; }
    [Required]
    public string Dodatak { get; set; }
  }
}