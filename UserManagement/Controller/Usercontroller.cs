using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data;
using UserManagement.Model;

namespace UserManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usercontroller : ControllerBase
    {
        private readonly DBContext _Context;
        public Usercontroller(DBContext Context)
        {
            _Context = Context;
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {

            _Context.User.Add(user);
            _Context.SaveChanges();
            return CreatedAtAction("AddUser", user);
        }

        [HttpGet]
        public  List<User> GetUsers() 
        {
            return _Context.User.ToList();
        }
    }
}
