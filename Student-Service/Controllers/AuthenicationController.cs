using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Student_Service.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Student_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenicationController : ControllerBase
    {


        List<User> users = null;
        IConfiguration _config;
        public AuthenicationController(IConfiguration config)
        {
            _config = config;
            if(users==null)
            {
                users = new List<User>
                 {
                      new User(){ Id=1, UserName="user1", Password="pass", RoleName="Manager"},

                      new User(){ Id=2, UserName="user2", Password="pass", RoleName="Admin"},
                      
                      new User(){ Id=3, UserName="user3", Password="pass", RoleName="User"}
                 };
            }
        }

        [HttpPost]
        public IActionResult Login(User user)
        { 
        IActionResult response = Unauthorized();

        User obj = CheckUser(user);
            if(obj!=null)
            {
               string tokenString =  GenerateToken(obj);
                response = Ok(new { token = tokenString });
            }

            return response;



        }

        string GenerateToken(User   user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new ClaimsIdentity(new Claim[]

         {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Role, user.RoleName)
        });

            var tokenHandler = new JwtSecurityTokenHandler();

            // Add roles as multiple claims
            //foreach (var role in user.Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.Name));
            //}
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer= _config["Jwt:Issuer"],
                Audience=_config["Jwt:Audience"],
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
                
        };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        User CheckUser(User user)
        {
            return users.FirstOrDefault(x=>x.UserName==user.UserName && x.Password==user.Password); 

        }






    }
}
