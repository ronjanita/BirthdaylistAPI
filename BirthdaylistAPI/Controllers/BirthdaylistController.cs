using BirthdaylistAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
