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

            var veh = await _context.Vehicles.ToListAsync();
           

            return Ok(veh);
        }

        [HttpPost]

        [AllowAnonymous]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVehiclebyNo), new { v_no = vehicle.v_no }, vehicle);

        }

    

       [HttpGet("vehicle/{v_no}")]

        public IActionResult GetVehiclebyNo(string v_no)
        {
            var result = _context.Vehicles.Where(e => e.v_no == v_no).ToList();
            return Ok(result);

        }




        private bool VehicleExists(string id)
        {
            return _context.Vehicles.Any(e => e.v_no == id);
        }
    }

}
