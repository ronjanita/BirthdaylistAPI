using BirthdaylistAPI.Models;

namespace BirthdaylistAPI.Interface_and_Repository
{
    public interface IBirthdaylistRepository
    {
        Task<ICollection<Birthdaylist>> GetCustomer();
        Task<string>AddCustomer(Birthdaylist newCustomer);
        Task<bool> GetCustomerById(int Id);
        Task<Birthdaylist> UpdateCustomer(Birthdaylist updatedCustomer);
        Task<bool>DeleteCustomer(Guid Id);
        Task<Birthdaylist> UpdateCongratulation(Birthdaylist updatedCongratulation);
    }
}
