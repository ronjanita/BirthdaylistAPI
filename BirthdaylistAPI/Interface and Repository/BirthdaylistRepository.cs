using BirthdaylistAPI.Data;
using BirthdaylistAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthdaylistAPI.Interface_and_Repository
{
    public class BirthdaylistRepository(DataContext context) : IBirthdaylistRepository
    {
        private readonly DataContext _context = context;
        async  Task<string> IBirthdaylistRepository.AddCustomer(Birthdaylist newCustomer)
        {
            await _context.Birthdaylist.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.Id.ToString();
            throw new NotImplementedException();
        }

        async  Task<bool> IBirthdaylistRepository.DeleteCustomer(Guid Id)
        {
           var customerRemove = await _context.Birthdaylist.FindAsync(Id);
            if (customerRemove == null) throw new NotImplementedException();
            _context.Birthdaylist.Remove(customerRemove);
            await _context.SaveChangesAsync();
            return true; 
        }

        async  Task<ICollection<Birthdaylist>> IBirthdaylistRepository.GetCustomer()
        {
            var customers = await _context.Birthdaylist.ToListAsync();
            return customers;
            throw new NotImplementedException();
        }

        async  Task<Birthdaylist> IBirthdaylistRepository.GetCustomerById(Guid Id)
        {
            var customer = await _context.Birthdaylist.FindAsync(Id);
            return customer;
            throw new NotImplementedException();
        }

        async public Task<Birthdaylist> UpdateCongratulation(Birthdaylist updatedCongratulation)
        {
            var updatedCongrats = await _context.Birthdaylist.FindAsync(updatedCongratulation.Id);
            if (updatedCongrats == null) throw new NotImplementedException();
            updatedCongrats.ShouldCongratulate = updatedCongratulation.ShouldCongratulate;
            await _context.SaveChangesAsync();
            return updatedCongrats;
            throw new NotImplementedException();
        }

        async public Task<Birthdaylist> UpdateCustomer(Birthdaylist updatedCustomer)
        {
            var customer = await _context.Birthdaylist.FindAsync(updatedCustomer.Id);
            if (customer == null) throw new NotImplementedException();
            customer.Name = updatedCustomer.Name;
            customer.Surname = updatedCustomer.Surname;
            customer.Birthday = updatedCustomer.Birthday;
            customer.ShouldCongratulate = updatedCustomer.ShouldCongratulate;
            await _context.SaveChangesAsync();
            return customer;
            throw new NotImplementedException();
        }
    }
}
