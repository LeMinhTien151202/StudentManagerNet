using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Dtos;
using StudentManager.Repositories;

namespace StudentManager.Controllers
{
    [Route("api/v1/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repository;
        public RoleController(IRoleRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            var roles = await _repository.GetAllRolesAsync();
            return Ok(roles);
        }
        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _repository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRole(RoleDTO roleDto)
        {
            try
            {
                var createdRole = await _repository.CreateRoleAsync(roleDto);
                return CreatedAtAction(nameof(GetRole), new { id = createdRole.Id }, createdRole);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDto)
        {
            if (id <= 0 || roleDto == null)
            {
                return BadRequest("Invalid ID or role data provided.");
            }
            try
            {
                var updatedRole = await _repository.UpdateRoleAsync(id, roleDto);
                return Ok(updatedRole);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _repository.DeleteRoleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
