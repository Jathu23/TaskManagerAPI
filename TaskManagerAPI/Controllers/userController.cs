using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TaskContext _taskContext;

        public UsersController(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _taskContext.Users.ToList();
            return Ok(users);
        }

        [HttpGet("single")]
        public IActionResult Get(int id)
        {
            var user = _taskContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] user newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User cannot be null.");
            }

            _taskContext.Users.Add(newUser);
            _taskContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _taskContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _taskContext.Users.Remove(user);
            _taskContext.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update([FromBody] user updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("User cannot be null.");
            }

            var existingUser = _taskContext.Users.FirstOrDefault(x => x.Id == updatedUser.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.name = updatedUser.name;
            existingUser.email = updatedUser.email;
            existingUser.password = updatedUser.password;
            existingUser.phonenumber = updatedUser.phonenumber;

            _taskContext.Users.Update(existingUser);
            _taskContext.SaveChanges();
            return Ok(existingUser);
        }
    }
}

