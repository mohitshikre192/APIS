using APIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using System;
using System.Data;
using System.Net;

namespace APIS.Controllers
{
    [Authorize]
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
            var drivers = _context.Drivers;

          //  var vehicles = await _context.Vehicles.ToListAsync() ;
                 
            
             var veh= from vehicle  in  _context.Vehicles
            join driver in _context.Drivers
                      on vehicle.d_id equals driver.d_id
                      select new
                      {   vehicle.v_no, vehicle.v_name, vehicle.fare,
                      vehicle.v_type,vehicle.sitting_cap,
                          driver.d_id,
                          driver.d_name,
                          driver.mobileno,
                          driver.address,
                          driver.licenseno
                      };


            return Ok(veh);
        }

        //[HttpGet]

        //public IActionResult GetVehiclebyNo(string vn)
        //{
        //    var result = _context.Vehicles.Where(e => e.v_no == vn).ToList();
        //    return Ok(result);

        //}

        [HttpGet("{v_no}")]

        public async Task<ActionResult<Vehicle>>
            GetById_V( string v_no)
        {
           // var vehicle = await _context.Vehicles.FindAsync(v_no);

            var veh= 
                      from vehicle in _context.Vehicles
                      join driver in _context.Drivers
                        on vehicle.d_id equals driver.d_id
                      where vehicle.v_no == v_no
                      select new
                      {
                          vehicle.v_no,
                          vehicle.v_name,
                          vehicle.fare,
                          vehicle.v_type,
                          vehicle.sitting_cap,
                          driver.d_id,
                          driver.d_name,
                          driver.mobileno,
                          driver.address,
                          driver.licenseno
                      };

            if (veh == null) return NotFound();
            else return Ok(veh);
        }

        //[HttpGet("query")]

        //public async Task<ActionResult<Vehicle>>GetById_D([FromQuery] int d_id)
        //    {
        //    var vehicle = await _context.Vehicles.FindAsync(d_id);
        //    if (vehicle == null) return NotFound();
        //    else return vehicle;
        //}


        //[HttpPost]

        //public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        //{
        //    _context.Vehicles.Add(vehicle);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetById_V), vehicle);
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
