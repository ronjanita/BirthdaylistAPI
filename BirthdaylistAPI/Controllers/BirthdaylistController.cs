using BirthdaylistAPI.Data;
using BirthdaylistAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirthdaylistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdaylistController : ControllerBase
    {
        private readonly DataContext _context;

        public BirthdaylistController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getBirthdaylist")]
        public ICollection<Birthdaylist> GetCustomer()
        {
            return [.. _context.Birthdaylist];
        }
        [HttpPost]
        public async Task<ActionResult<List<Birthdaylist>>> AddCustomer(Birthdaylist newCustomer)
        {
            _context.Birthdaylist.Add(newCustomer);
            await _context.SaveChangesAsync();
            return Ok(await _context.Birthdaylist.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Birthdaylist>> GetCustomerById(int Id)
        {
            var customer = await _context.Birthdaylist.FindAsync(Id);
            if (customer is null)
                return NotFound("Customer not found.");
            else
                return Ok(customer);
        }
        [HttpPut]
        public async Task<ActionResult<Birthdaylist>> UpdateCustomer(Birthdaylist updatedCustomer)
        {
            var dbBirthdaylist = await _context.Birthdaylist.FindAsync(updatedCustomer);
            if (dbBirthdaylist is null)
            {
                return NotFound("Customer not found.");
            }
            else
            {
                dbBirthdaylist.Name = updatedCustomer.Name;
                dbBirthdaylist.Surname = updatedCustomer.Surname;
                dbBirthdaylist.Birthday = updatedCustomer.Birthday;
                dbBirthdaylist.ShouldCongratulate = updatedCustomer.ShouldCongratulate;
                await _context.SaveChangesAsync();
            }
            return Ok(await _context.Birthdaylist.ToListAsync());
        }
    }
}
