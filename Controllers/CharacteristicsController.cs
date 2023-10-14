using _14._10_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _14._10_ASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacteristicsController : ControllerBase
    {
        private readonly PhonesContext _context;

        public CharacteristicsController(PhonesContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("GetCharacteristics")]
        public async Task<ActionResult<IEnumerable<Characteristics>>> GetAll()
        {
            if (_context.Characteristicss == null) return BadRequest();
            return await _context.Characteristicss.ToListAsync();
        }

        [HttpPost("AddCharacteristics")]
        public ActionResult<Characteristics> AddCharacteristics(Characteristics? chars)
        {
            if (_context.Characteristicss == null) return BadRequest();
            if (chars == null) return BadRequest();
            _context.Characteristicss.Attach(chars).State = EntityState.Added;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteManufacturer")]
        public ActionResult<Characteristics> DeleteCharacteristics(Characteristics? chars)
        {
            if (chars == null) return BadRequest();
            _context.Characteristicss.Attach(chars).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }
    }
}
