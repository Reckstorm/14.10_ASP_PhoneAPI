using _14._10_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace _14._10_ASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonesController : ControllerBase
    {
        private readonly PhonesContext _context;
        public PhonesController(PhonesContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("GetPhones")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAll() 
        {
            if (_context.Phones == null) return BadRequest();
            return await _context.Phones.
                Include(p => p.Manufacturer).
                Include(p => p.Characteristics).
                ToListAsync();
        }

        [HttpPost("GetPhonesByFilter")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetPhonesByFilter(Characteristics? chars)
        {
            if (_context.Phones == null) return BadRequest();
            List<Phone> temp = new List<Phone>();
            foreach (var phone in _context.Phones.Include(p => p.Characteristics))
            {
                if (phone.Characteristics == null) continue;
                if (phone.Characteristics.Camera.Equals(chars.Camera) ||
                phone.Characteristics.Memory.Equals(chars.Memory) ||
                phone.Characteristics.Battery.Equals(chars.Battery) ||
                phone.Characteristics.Screen.Equals(chars.Screen)) temp.Add(phone);
            }
            return temp;
        }
        [HttpPost("GetPhonesByAllFilters")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetPhonesByAllFilters(Characteristics? chars)
        {
            if (_context.Phones == null) return BadRequest();
            return _context.Phones.Include(p => p.Characteristics).Where
                (p => p.Characteristics != null &&
                (chars.Camera.IsNullOrEmpty() || p.Characteristics.Camera.Equals(chars.Camera)) &&
                (chars.Memory.IsNullOrEmpty() || p.Characteristics.Memory.Equals(chars.Memory)) &&
                (chars.Battery.IsNullOrEmpty() || p.Characteristics.Battery.Equals(chars.Battery)) &&
                (chars.Screen.IsNullOrEmpty() || p.Characteristics.Screen.Equals(chars.Screen))).ToList();
        }

        [HttpGet("GetPhonesByMan")]
        public ActionResult<IEnumerable<Phone>> GetAllByMan(Manufacturer man)
        {
            List<Phone> temp = new List<Phone>();
            if (_context.Phones == null || man.Name.Equals(string.Empty)) return BadRequest();
            foreach (var phone in _context.Phones)
            {
                if (phone.Manufacturer.Equals(man)) temp.Add(phone);
            }
            return temp;
        }

        [HttpPost("AddPhone")]
        public ActionResult<Phone> AddPhone(Phone? phone)
        {
            if (phone == null) return BadRequest();
            _context.Phones.Attach(phone).State = EntityState.Added;
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdatePhone")]
        public ActionResult<Phone> UpdatePhone(string? model, Phone? phoneNew)
        {
            if (phoneNew == null) return BadRequest();
            Phone? temp = _context.Phones.FirstOrDefault(p => p.Model.Equals(model));
            if (temp == null) return BadRequest();
            temp.Model = phoneNew.Model;
            temp.Manufacturer = phoneNew.Manufacturer;
            temp.Characteristics = phoneNew.Characteristics;
            _context.Phones.Attach(temp).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeletePhone")]
        public ActionResult<Phone> DeletePhone(Phone? phone)
        {
            if (phone == null) return BadRequest();
            _context.Phones.Attach(phone).State= EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }
    }
}
