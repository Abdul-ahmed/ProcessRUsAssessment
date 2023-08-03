using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessRUsAssessment.Models;
using ProcessRUsAssessment.RquestResponseDTOs;
using System.Runtime.CompilerServices;


namespace ProcessRUsAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        [ActivatorUtilitiesConstructor]
        public AuthController(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        public async Task<ActionResult> Login([FromBody] LoginUser loginUser)
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

            return Ok();
        }

        // GET: api/Auth/users
        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/Auth/roles
        [HttpGet]
        [Route("roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }
    }
}
