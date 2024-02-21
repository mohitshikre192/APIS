using APIS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public Context _context;

        public VehicleController(Context context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicle()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return Ok(vehicles);
        }

        //[HttpGet("query")]

        //public async Task<ActionResult<Vehicle>>
        //    GetById_V([FromQuery] string v_no)
        //{
        //    var vehicle = await _context.Vehicles.FindAsync(v_no);
        //    if (vehicle == null) return NotFound();
        //    else return vehicle;
        //}

        //[HttpGet("query")]

        //public async Task<ActionResult<Vehicle>>GetById_D([FromQuery] int d_id)
        //    {
        //    var vehicle = await _context.Vehicles.FindAsync(d_id);
        //    if (vehicle == null) return NotFound();
        //    else return vehicle;
        //}


        //[HttpPut("{v_no}")]

        //public async Task<ActionResult> updateVehicle(string id, Vehicle vehicle)
        //{

        //    if (id != vehicle.v_no)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(vehicle).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VehicleExists(id))
        //        {
        //            return NotFound();

        //        }
        //        else
        //        {
        //            throw;
        //        }

        //    }
        //    return NoContent();

        //}


        //[HttpDelete("{v_no}")]


        //public async Task<ActionResult<Vehicle>> DeleteVehicle(string v_no)
        //{
        //    var vehicle = await _context.Vehicles.FindAsync(v_no);
        //    if (vehicle == null)
        //    { return NotFound(); }
        //    _context.Vehicles.Remove(vehicle);
        //    await _context.SaveChangesAsync();

        //    return vehicle;


        //}

        private bool VehicleExists(string id)
        {
            return _context.Vehicles.Any(e => e.v_no == id);
        }
    }

}
