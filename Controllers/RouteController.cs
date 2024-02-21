using APIS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        Context _context;
        public RouteController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Route>>> GetAllRoutes()
        {
            var routes = await _context.Routes.ToListAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Models.Route>> GetbyId(int id)

        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            else
                return route;

        }

        [HttpPost]
        public async Task<ActionResult<Models.Route>> CreateRoute(Models.Route route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetbyId), new { id = route.r_id }, route);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> updateRoute(int id, Models.Route route)
        {
            if (id !=route.r_id)
            {
                return BadRequest();
            }
            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Models.Route>> DeleteRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
                return NotFound();
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return route;

        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.r_id == id);
        }







    }
}
