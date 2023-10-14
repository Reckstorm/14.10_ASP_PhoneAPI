using _14._10_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _14._10_ASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : ControllerBase
    {
        private readonly PhonesContext _context;
        public ManufacturersController(PhonesContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("GetManufacturer")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAll()
        {
            if (_context.Phones == null) return BadRequest();
            return await _context.Manufacturers.ToListAsync();
        }

        [HttpPost("AddManufacturer")]
        public ActionResult<Manufacturer> AddManufacturer(Manufacturer? man)
        {
            if (_context.Phones == null) return BadRequest();
            if (man == null) return BadRequest();
            _context.Manufacturers.Add(man);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateManufacturer")]
        public ActionResult<Manufacturer> UpdateManufacturer(string? man, Manufacturer? manNew)
        {
            if (man.Equals(string.Empty) || manNew == null) return BadRequest();
            Manufacturer? temp = _context.Manufacturers.FirstOrDefault(m => m.Name.Equals(man));
            if (temp == null) return BadRequest();
            temp.Name = manNew.Name;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteManufacturer")]
        public ActionResult<Manufacturer> DeleteManufacturer(Manufacturer? man)
        {
            Manufacturer? temp = _context.Manufacturers.FirstOrDefault(m => m.Name.Equals(man.Name));
            if (temp == null) return BadRequest();
            _context.Manufacturers.Remove(man);
            _context.SaveChanges();
            return Ok();
        }
    }
}
