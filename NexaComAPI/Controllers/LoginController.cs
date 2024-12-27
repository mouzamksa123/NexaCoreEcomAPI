using App.ApplicationLayer.Interface;
using App.CommonLayer.DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexaComAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserBusiness _userBusiness;
        private readonly IPasswordHasher _passwordHasher;


        public LoginController(IConfiguration configuration, IUserBusiness userBusiness, IPasswordHasher passwordHasher)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide username and password");
            }
            UserLoginResponseModel response = new() { UserName = model.UserName };
            string audience = string.Empty;
            string issuer = string.Empty;
            byte[] key = null;
            issuer = _configuration.GetValue<string>("LocalIssuer");
            audience = _configuration.GetValue<string>("LocalAudience");
            key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSceret"));

            if (model.UserName != null && model.UserPassword != null)
            {
                UserRegistrationModel userInfo = await _userBusiness.GetUserLoginInfo(model);
                if (userInfo != null)
                {
                    string userpassword = userInfo.PasswordHash;
                    if (!string.IsNullOrWhiteSpace(userpassword) && _passwordHasher.Check(userpassword, model.UserPassword).Verified)
                    {

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenDescriptor = new SecurityTokenDescriptor()
                        {
                            Issuer = issuer,
                            Audience = audience,
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                        //Username
                        new Claim(ClaimTypes.Name, model.UserName),
                        //Role
                        new Claim(ClaimTypes.Role, "Admin")
                            }),
                            Expires = DateTime.Now.AddHours(4),
                            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                        };

                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        response.loginDateTime = DateTime.Now;
                        response.roleName = "Admin";
                        response.token = tokenHandler.WriteToken(token);
                    }
                    else
                    {
                        return Ok("Invalid Password");
                    }
                }
            }
            else
            {
                return Ok("Invalid username and password");
            }
            return Ok(response);
        }
    }
}

