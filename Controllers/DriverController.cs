using APIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace APIS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        private readonly Context _context;

        public DriverController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAllDriver()
        {

            var drivers = await _context.Drivers.ToListAsync();

            return Ok(drivers);


        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Driver>> GetbyId(int id)
        { 
        var driver = await _context.Drivers.FindAsync(id);

            if (driver == null) { return NotFound(); }
            return driver;
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<ActionResult<Driver>> SignUP(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetbyId", new { id = driver.d_id }, driver);
                
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateDriver(int id, Driver driver)
        {
            if (id != driver.d_id)
            {
                return BadRequest();

            }
            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
                {
                    return NotFound();
                }
                else
                { throw;
                }
            
            }
            return NoContent();

        }


        [HttpDelete("{id}")]


        public async Task<ActionResult<Driver>> DeleteDriver(int id)
        {
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }
            _context.Drivers.Remove(drivers);
            await _context.SaveChangesAsync();

            return drivers;
        
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.d_id == id);
        }

    }
}
