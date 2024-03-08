using APIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Context context;
        public UserController(Context _context) {
          context= _context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<User>> GetUserbyID(int id)
        { 
         var user= await context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            else
                return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserbyID), new { id = user.Id }, user);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult> updateUsers(int id, User user)
        {

            if (id != user.Id)
            { 
            return BadRequest();
            }
            context.Entry(user).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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


        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            { return NotFound(); }
            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return user;


        }

        private bool UsersExists(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }
        

    }
}
