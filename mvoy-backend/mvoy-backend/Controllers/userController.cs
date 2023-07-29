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

        //Login

        public IConfiguration _Configuration;
        public userControllers(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public dynamic Login([FromBody] object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.usuario.ToString();
            string password = data.password.ToString();

            usuario usuario = usuario.DB().Where(x => x.user == user && x.password == password).FirstOrDefault();

            if (usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    Result = ""
                };
            }
            var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                  new Claim("id", usuario.idUsuario),
                  new Claim("usuario", usuario.user)

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
            return new
            {
                success = true,
                message = "Exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }








}
}
