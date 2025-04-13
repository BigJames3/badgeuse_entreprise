using Microsoft.AspNetCore.Mvc;
using API_Pointage.Models;
using Microsoft.EntityFrameworkCore;
using API_Pointage.DbContext;

namespace API_Pointage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/User/{UserId}
        [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetUser(Guid UserId)
        {
            var user = await _context.Users.FindAsync(UserId);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.UserId = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { UserId = user.UserId }, user);
        }

        // PUT api/User/{UserId}
        [HttpPut("{UserId}")]
        public async Task<IActionResult> PutUser(Guid UserId, User user)
        {
            if (UserId != user.UserId)
            {
                return BadRequest();
            }

            user.UpdatedAt = DateTime.UtcNow;
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/User/{UserId}
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(Guid UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid UserId)
        {
            return _context.Users.Any(e => e.UserId == UserId);
        }
    }
}
