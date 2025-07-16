using AutoMapper;
using BirthdaylistAPI.Data;
using BirthdaylistAPI.Interface_and_Repository;
using BirthdaylistAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BirthdaylistAPI.DTOs;

namespace BirthdaylistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdaylistController(IBirthdaylistRepository birthdaylistRepository, IMapper mapper): ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper = mapper;
        private readonly IBirthdaylistRepository _birthdaylistRepository = birthdaylistRepository;

        [HttpGet]
        [Route("getBirthdaylist")]
        public async Task<ActionResult<List<BirthdaylistDTO>>> GetCustomer()
        {
            ICollection<Birthdaylist> customer = await _birthdaylistRepository.GetCustomer();
            List<BirthdaylistDTO> customerDTO = _mapper.Map<List<BirthdaylistDTO>>(customer);
            return Ok(customerDTO);
        }
        [HttpPost]
        public async Task<ActionResult<List<Birthdaylist>>> AddCustomer(Birthdaylist newCustomer)
        {
            Birthdaylist mappedCustomer = _mapper.Map<Birthdaylist>(newCustomer);
            _context.Birthdaylist.Add(newCustomer);
            await _context.SaveChangesAsync();
            return Ok(await _context.Birthdaylist.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Birthdaylist>> GetCustomerById(Guid Id)
        {
            var customer = await _birthdaylistRepository.GetCustomerById(Id);
            if (customer is null)
                return NotFound("Customer not found.");
            var customerDTO = _mapper.Map<BirthdaylistDTO>(customer);
            return Ok(customerDTO);
        }
        [HttpPut]
        public async Task<ActionResult<Birthdaylist>> UpdateCustomer(Guid Id, [FromBody] Birthdaylist updatedCustomer)
        {
            var dbBirthdaylist = await _birthdaylistRepository.GetCustomerById(Id);
            if (dbBirthdaylist is null)
            {
                return NotFound("Customer not found.");
            }
            _mapper.Map(updatedCustomer, dbBirthdaylist);
            await _birthdaylistRepository.UpdateCustomer(dbBirthdaylist);
            var updatedCustomerDTO = _mapper.Map<BirthdaylistDTO>(dbBirthdaylist);
            return Ok(updatedCustomerDTO);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(Guid Id)
        {
            var customer = await _context.Birthdaylist.FindAsync(Id);
            if (customer is null)
            {
                return NotFound("Customer not found");
            }
            await _birthdaylistRepository.DeleteCustomer(Id);
            return NoContent();
        }
        public async Task<ActionResult<Birthdaylist>> UpdateCongratulation(Birthdaylist updatedCongratulation)
        {
            var dbBirthdaylist = await _context.Birthdaylist.FindAsync(updatedCongratulation);
            if (dbBirthdaylist is null)
            {
                return NotFound("Customer not found.");
            }
            _mapper.Map(updatedCongratulation, dbBirthdaylist);
            await _birthdaylistRepository.UpdateCongratulation(dbBirthdaylist);
            var updatedCongratulationDTO = _mapper.Map<BirthdaylistDTO>(dbBirthdaylist);
            return Ok(updatedCongratulationDTO);
        }
    }
}
