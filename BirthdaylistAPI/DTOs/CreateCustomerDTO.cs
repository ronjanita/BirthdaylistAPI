namespace BirthdaylistAPI.DTOs
{
    public class CreateCustomerDTO : BirthdaylistDTO
    {
        new public required string Name { get; set; }
        new public required string Surname { get; set; }
        new public required DateTime Birthday { get; set; }
        new public required bool ShouldCongratulate { get; set; }
    }
}
