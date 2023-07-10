using Microsoft.AspNetCore.Mvc;
using mvoy.core.Enums;
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

        // GET api/<userController>/5
        [HttpGet("{cedula}")]
        public string GetByCedula(string cedula)
        {
            return "value";
        }

        // POST api/<userController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] RegisterDto user)
        {
            UserContactInfo contactInfo= new UserContactInfo();
            contactInfo.address = user.address;
            contactInfo.phoneNumber = user.phoneNumber;
            contactInfo.relativePhoneNumber = user.relativePhoneNumber;
            contactInfo.relativeName = user.relativeName;
            
            User usr= new User();
            usr.Name= user.Name;
            usr.middleName = user.middleName;
            usr.lastname= user.lastname1;
            usr.lastname2= user.lastname2;
            usr.cedula= user.cedula;
            usr.IsDeleted= false;
            usr.CreationDate= DateTime.Now;
            usr.birthDate = user.birthDate;
            usr.gender = user.gender;
            usr.email= user.email;
            usr.UserKind = UserType.Customer;
            usr.contactInfoId = await _userService.createContactInfo(contactInfo);

            if (await _userService.SaveUser(usr))
            {
                
                return Ok(usr);
            }
            else
            {
                await _userService.removeContactInfo(usr.contactInfoId);
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
