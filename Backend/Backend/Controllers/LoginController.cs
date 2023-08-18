using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Backend.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST");
            if (userLogin == null)
            {
                return BadRequest("Invalid client request");
            }
            else if (userLogin.Email == "" || userLogin.Password == "")
            {
                return BadRequest("Invalid client request");
            }
            var user = _context.Users.FirstOrDefault(u => u.email == userLogin.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            if (user.password != userLogin.Password)
            {
                return Unauthorized();
            }
            var cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("user_id", user.Id.ToString(), cookie);
            Response.Cookies.Append("email", user.email, cookie);

            var result = new
            {
                success = true,
            };

            return Ok(
                result
            );
        }

    }
}
