using BirthdaylistAPI.Models;

namespace BirthdaylistAPI.Interface_and_Repository
{
    public interface IBirthdaylistRepository
    {
        Task<ICollection<Birthdaylist>> GetCustomer();
        Task<string>AddCustomer(Birthdaylist newCustomer);
        Task<Birthdaylist> GetCustomerById(Guid Id);
        Task<Birthdaylist> UpdateCustomer(Birthdaylist updatedCustomer);
        Task<bool>DeleteCustomer(Guid Id);
        Task<Birthdaylist> UpdateCongratulation(Birthdaylist updatedCongratulation);
    }
}
