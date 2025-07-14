
namespace BirthdaylistAPI.Models;

public class Birthdaylist
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required DateTime Birthday { get; set; }
    public required bool ShouldCongratulate { get; set; }
}
