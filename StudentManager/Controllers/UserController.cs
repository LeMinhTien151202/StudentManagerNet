using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using StudentManager.Dtos;
using StudentManager.Models;
using StudentManager.Repositories;
using StudentManager.Services;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegisterDTO>>> GetUsers()
        {
            var users = await _repository.GetAllUsersAsync();
            return Ok(users);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegisterDTO>> GetUser(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserRegisterDTO>> CreateUser(UserRegisterDTO userDto)
        {
            try
            {
                var createdUser = await _repository.CreateUserAsync(userDto);
                return createdUser;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/User/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUser(int id, UserRegisterDTO userDto)
        {
            if (id <= 0 || userDto == null)
            {
                return BadRequest("Invalid ID or user data provided.");
            }
            try
            {
                var updatedUser = await _repository.UpdateUserAsync(id, userDto);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }
            try
            {
                var deleted = await _repository.DeleteUserAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            var result = await _repository.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var token = await _repository.LoginAsync(userLoginDTO);

            if (token == null)
                return Unauthorized("Invalid username or password.");

            return Ok(new
            {
                Message = "Login successful.",
                Token = token
            });
        }
    }
}
