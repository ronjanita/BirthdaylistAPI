using BirthdaylistAPI;
using AutoMapper;
namespace BirthdaylistAPI.DTOs
{
    public class BirthdaylistDTO
    {
        public  string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public  DateTime Birthday { get; set; }
        public  bool ShouldCongratulate { get; set; }   
    }
}
