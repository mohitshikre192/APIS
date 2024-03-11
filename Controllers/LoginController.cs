using APIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Context context;
        private IConfiguration _config;
        
        public LoginController(IConfiguration configuration,Context context)
        {
            _config = configuration;
            this.context = context;
        }

        private Login Authenticate(Login user) 
        {
            Login _user = null;
           

            if (user.role == "user")
            {
                if (context.Users.Any(x => x.mobile_no.Equals(user.mobile_no) &&x.password.Equals(user.password)))
                {
                    _user = new Login
                    {
                        mobile_no = user.mobile_no,
                        password = user.password,
                        role = user.role
                    };

                }
            }

            else if(user.role == "driver")
                 if (context.Drivers.Any(x => x.mobileno.Equals(user.mobile_no) && x.password.Equals(user.password)))
                {
                _user = new Login
                {
                    mobile_no = user.mobile_no,
                    password = user.password,
                    role = user.role
                };

            }
            return _user;



        }


        private string GeneratedToken(Login users)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
                                            _config["JwtSettings:Audience"], null,
                                            expires: DateTime.Now.AddMinutes(5),
                                            signingCredentials:credentials

                                            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login(Login user)
        {
            IActionResult response = Unauthorized();
            var user_ = Authenticate(user);
            if (user_ != null)
            {
                var token = GeneratedToken(user_);
                response = Ok(new { token = token });
            }
            return response;
}

        }

    }
