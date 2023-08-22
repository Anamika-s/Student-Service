using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Student_Service.Models;
using System.IdentityModel.Tokens.Jwt;
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
                      new User(){ Id=1, UserName="user1", Password="pass"},

                      new User(){ Id=2, UserName="user2", Password="pass"},

                      new User(){ Id=3, UserName="user3", Password="pass"}
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
               string tokenString =  GenerateToken(obj.UserName);
                response = Ok(new { token = tokenString });
            }

            return response;



        }

        string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                            _config["Jwt:Audience"],
                                             null,
                                            expires: DateTime.Now.AddMinutes(120),
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        User CheckUser(User user)
        {
            return users.FirstOrDefault(x=>x.UserName==user.UserName && x.Password==user.Password); 

        }






    }
}
