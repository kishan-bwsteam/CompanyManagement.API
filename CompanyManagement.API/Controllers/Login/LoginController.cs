using CompanyManagement.Services.Service.Abstract;
using Dto.Request;
using Dto.Responses;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;


namespace CompanyManagement.Login
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService1;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            this.loginService1 = loginService;
            _config = config;
        }

        //----------------------------------Save Update Login information----------

        [HttpPost]


        public IActionResult Logins(LoginRequest user)
        {
            try
            {
                IActionResult response = Unauthorized();
                LoginResponse userBasic = this.loginService1.Login(user);
                if (userBasic != null && userBasic.UserID > 0)
                {
                    var tokenString = GenerateJWT(userBasic);
                    response = Ok(new
                    {
                        token = tokenString,
                        userDetails = userBasic,
                    });
                }
                else
                {
                    var tokenString = string.Empty;
                    response = Ok(new
                    {
                        token = tokenString,
                        userDetails = userBasic,
                    });
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //------------------------ Genrate JWT-----------------------------------


        [HttpGet]
        string GenerateJWT(LoginResponse userInfo)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
               {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("userID",userInfo.UserID.ToString()),
                new Claim("userTypeId",userInfo.UserTypeID.ToString()),
                 new Claim("firstName",userInfo.FirstName.ToString()),
                  new Claim("lastName",userInfo.LastName.ToString()),
                   
                //new Claim("roleName",userInfo.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(300),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //[HttpGet]
        //[Route("return")]
        //public string Index1()
        //{ return "Hello"; }
    }
}
