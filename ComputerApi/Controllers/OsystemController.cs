using ComputerApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<Osystem> Post(CreateOsDto osdto)
        {
            var os = new Osystem
            {
                Id =Convert.ToString( Guid.NewGuid()),
                Name = osdto.name
            };
            if (os != null) { 
                _context.Osystems.Add(os);
                _context.SaveChanges();
                return StatusCode(201, os);
            }
            
            return BadRequest();
        }
    }
}
