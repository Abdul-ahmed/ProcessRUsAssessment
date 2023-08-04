using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProcessRUsAssessment.Models;
using ProcessRUsAssessment.RquestResponseDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace ProcessRUsAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        [ActivatorUtilitiesConstructor]
        public AuthController(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult> Register([FromBody] CreateUser createUser)
        {
            var user = _mapper.Map<User>(createUser);
            user.UserName = createUser.Email;

            var result = await _userManager.CreateAsync(user, createUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "FrontOffice");
            }

            var errors = result.Errors;
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        // POST: api/Auth/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user is null)
            {
                return NotFound();
            }

            bool validatePassword = await _userManager.CheckPasswordAsync(user, loginUser.Password);
            if (!validatePassword)
            {
                return Unauthorized();
            }

            var token = await GenerateToken(user);
            var authResponse = new AuthResponse
            {
                UserId = user.Id,
                Token = token
            };

            return Ok(authResponse);
        }

        // GET: api/Auth/users
        [HttpGet]
        [Route("users")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/Auth/roles
        [HttpGet]
        [Route("roles")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }

        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    
}
