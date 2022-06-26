#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagementSystem.Data;
using RealEstateManagementSystem.Models;

namespace RealEstateManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Home
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomes()
        {
            return await _context.Homes.ToListAsync();
        }

        // GET: api/Home/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return home;
        }

        // GET: api/Home/GetHomesByCategory/5
        [HttpGet("GetHomesByCategory/{CategoryId}")]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomesByCategory(int CategoryId)
        {
            var homes = await _context.Homes.Where(a=>a.CategoryId==CategoryId).ToListAsync();

            if (homes == null)
            {
                return NotFound();
            }

            return homes;
        }

        // GET: api/Home/GetHomesByZipCode/5
        [HttpGet("GetHomesByZipCode/{ZipCode}")]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomesByZipCode(int ZipCode)
        {
            var homes = await _context.Homes.Where(a => a.ZipCode == ZipCode).ToListAsync();

            if (homes == null)
            {
                return NotFound();
            }

            return homes;
        }

        // GET: api/Home/GetHomesBySearch/5
        [HttpGet("GetHomesBySearch")]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomesBySearch(decimal MaxPrice,decimal SquareFoot, int NoOfBeds, int NoOfBathrooms)
        {
            var homes = await _context.Homes.Where(a => a.Price == MaxPrice && a.SquareFoot == SquareFoot && a.NoOfBedrooms == NoOfBeds && a.NoOfBathrooms == NoOfBathrooms).ToListAsync();

            if (homes == null)
            {
                return NotFound();
            }

            return homes;
        }

        // PUT: api/Home/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home home)
        {
            if (id != home.HomeId)
            {
                return BadRequest();
            }

            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetHome", new { id = id }, home);
        }

        // POST: api/Home
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHome", new { id = home.HomeId }, home);
        }

        // DELETE: api/Home/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
