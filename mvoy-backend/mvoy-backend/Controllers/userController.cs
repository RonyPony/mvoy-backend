using Microsoft.AspNetCore.Mvc;
using mvoy.core.Interface;
using mvoy.core.Models;
using mvoy.data.DTOs;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvoy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserService _userService;

        public userController(IUserService srv)
        {
            _userService = srv;
        }
        // GET: api/<userController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<userController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserDto user)
        {
            User usr= new User();
            usr.Name= user.Name;
            usr.lastname= user.lastname;
            usr.cedula= user.cedula;
            usr.IsDeleted= false;
            usr.CreationDate= DateTime.Now;

            if (await _userService.SaveUser(usr))
            {
                return Ok(usr);
            }
            else
            {
                return StatusCode(500,"Error creating new user");
            }
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
