using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using mvoy.core.Enums;
using mvoy.core.Interface;
using mvoy.core.Models;
using mvoy.data.DTOs;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvoy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserService _userService;

        public IConfiguration _Configuration;
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
            UserRole baseRole = new UserRole();
            baseRole.roleName= "basic1";
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
            usr.password = user.password;
            usr.roles = new List<UserRole> { baseRole};

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

        //Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto optData)
        {
            //var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            //string user = data.usuario.ToString();
            //string password = data.password.ToString();
            //Guid userId = await _userService.
            User user = await _userService.getUserByEmail(optData.email);
            
            //usuario usuario = usuario.DB().Where(x => x.user == user && x.password == password).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Usuario no existe, favor registrate",
                    result = ""
                });
            }
            if (user.password!=optData.password)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                });
            }
            var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                  new Claim("id", user.Id.ToString()),
                  new Claim("email", user.email)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signin

               );
            return Ok(new
            {
                success = true,
                message = "Exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            });
            
        }
    }


}
