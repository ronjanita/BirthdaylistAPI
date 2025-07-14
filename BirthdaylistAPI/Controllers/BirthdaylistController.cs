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
        public ICollection<Birthdaylist> GetBirthdaylist()
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
    }

}
