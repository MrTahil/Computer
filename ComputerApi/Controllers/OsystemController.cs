using ComputerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers
{   
    [Route("osystem")]
        [ApiController]
    public class OsystemController : Controller
    {
        private readonly ComputerContext _context;

        public OsystemController(ComputerContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Osystem>> Post(CreateOsDto osdto)
        {
            var os = new Osystem
            {
                Id =Convert.ToString( Guid.NewGuid()),
                Name = osdto.name
            };
            if (os != null) { 
                await _context.Osystems.AddAsync(os);
                await _context.SaveChangesAsync();
                return StatusCode(201, os);
            }
            
            return BadRequest();
        }


        [HttpGet]
        public async Task<ActionResult<Osystem>> Get()
        {
            return Ok(await _context.Osystems.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Osystem>> GetbyId(string id)
        {
            var os = _context.Osystems.FirstOrDefaultAsync(s => s.Id == id);
            if (os != null)
            {
                return Ok(os);
            }
            return NotFound(new { message = "Nincs ilyen találat." });
        }
    }
}
