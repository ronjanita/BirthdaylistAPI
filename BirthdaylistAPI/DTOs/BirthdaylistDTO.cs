namespace BirthdaylistAPI.DTOs
{
    public class BirthdaylistDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime Birthday { get; set; }
        public required bool ShouldCongratulate { get; set; }   
    }
}
