using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompController : ControllerBase
    {
        private readonly ComputerContext _context;


        [HttpPost]
        public async Task<ActionResult<Comp>> Post(CreateCompDto cdto)
        {
            var os = new Comp
            {
                Id = Convert.ToString(Guid.NewGuid()),
                Brand = cdto.Brand,
                Type = cdto.Type,
                Memory = cdto.Memory,
                Display = cdto.Display,
                OsId = cdto.OsId,
                CreatedTime=DateTime.Now
            };
            if (os != null)
            {
                await _context.Comps.AddAsync(os);
                await _context.SaveChangesAsync();
                return StatusCode(201, os);
            }

            return BadRequest();
        }




        [HttpGet]
        public async Task<ActionResult<Comp>> Get()
        {
            return Ok(await _context.Comps.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comp>> GetbyId(string id)
        {
            var os = _context.Comps.FirstOrDefaultAsync(s => s.Id == id);
            if (os != null)
            {
                return Ok(os);
            }
            return NotFound(new { message = "Nincs ilyen találat." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Comp>> Put(string id,UpdateCompDto ucdto )
        {
            var existos = await _context.Comps.FirstOrDefaultAsync(x => x.Id == id);
            if (existos != null)
            {
                existos.Brand = ucdto.Brand;
                existos.OsId    = ucdto.OsId;
                existos.Display=ucdto.Display;
                existos.Type = ucdto.Type;
                existos.Memory = ucdto.Memory;   
                _context.Comps.Update(existos);
                await _context.SaveChangesAsync();
                return Ok(existos);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult<Comp>> Delete(string id)
        {
            var os = await _context.Comps.FirstOrDefaultAsync(eos => eos.Id == id);
            if (os != null)
            {
                _context.Comps.Remove(os);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Faha" });
            }
            return NotFound(new { message = "nincs ilyen" });
        }




        [HttpGet("Data/{id}")]
        public async Task<ActionResult<Comp>> GetlowCompwdata(string id)
        {
            using (var contex = new ComputerContext())
            {

                var comb = contex.Comps.FirstOrDefault(x => x.Id == id);

                var data = contex.Osystems.Select(x => new { comb.Brand, comb.Memory,comb.Display,comb.Type }).Where(x => x.OsId == id).ToList(); ;



                if (data != null)
                {
                    return Ok(data);
                }

                return NotFound();
            }
        }
    }
}
