using Microsoft.AspNetCore.Mvc;
using UserManagement.Data;
using UserManagement.Model;

namespace UserManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly DBContext _context;

        public UserController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if(_context.User == null)
            {
                return Problem("Entity set 'DBContext.User'  is not found.");
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get User",new {id = user.Id }, user);
        }
    }
}
