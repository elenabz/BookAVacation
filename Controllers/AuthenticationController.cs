using BookAVacation.Authentication;
using BookAVacation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookAVacation.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<User> userManager, IConfiguration configuration) {
            _userManager = userManager;
            _configuration = configuration;

        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegistrationModel registrationModel)
        {
            var existingUser = await _userManager.FindByNameAsync(registrationModel.Email);
            if(existingUser != null) {
                return Conflict("User already exists.");

            }

            var newUser = new User
            {
                Email = registrationModel.Email,
                Reservations = new List<Reservation>(),
                UserName = registrationModel.Username,
                // SecurityStamp is from base class to make this user unique
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(newUser, registrationModel.Password);

            if(result.Succeeded)
            {
                return Ok("User successfully created.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    , $"Failed to create user: {string.Join(" ", result.Errors.Select(e => e.Description))}");
            }
        }

        // user can login and will receive a jwt token to use for requesting resources
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {

            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if(user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return Unauthorized();
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured.")));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new LoginResponse
            {
                JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }
    }
}
