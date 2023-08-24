using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using WebAPI.Authentication;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Entities;
using WebAPI.Mapping;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RingsController : ControllerBase
    {
        private readonly RingsDbContext _context;

        public RingsController(RingsDbContext context)
        {
            _context = context;
        }

        [SwaggerOperation(Summary = "Retrieves all rings")]
        [HttpGet]
        public IActionResult GetAllRings()
        {
            var ringsDto = MapperService.MapRings(_context.Rings.ToList(), _context.HowToGet.ToList());
            return Ok(ringsDto);
        }

        [SwaggerOperation(Summary = "Retrieves ring by name")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetRingByName(string name)
        {
            var ring = await _context.Rings.FirstOrDefaultAsync(r => r.Name.Replace(" ", "") == name.Replace(" ", ""));
            var howToGet = _context.HowToGet.Where(h => h.RingId == ring.Id).ToListAsync();

            if (ring == null)
            {
                return Ok(null);
            }
     
            var ringDto = MapperService.MapRing(ring, await howToGet);
            return Ok(ringDto);
        }

        [SwaggerOperation(Summary = "Insert a new ring into database")]
        [HttpPost]
        [ServiceFilter(typeof(AuthenticationFilter))]
        public IActionResult InsertRing(RingDto ringDto)
        {
            var ring = MapperService.MapRing(ringDto);
            _context.Add(ring);
            _context.SaveChanges();
            
            return Created($"api/rings/{ring.Id}", ring);
        }
    }
}