using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Dtos;
using StudentManager.Repositories;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _repository;
        public ParentController(IParentRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Parent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentDTO>>> GetParents()
        {
            var parents = await _repository.GetAllAsync();
            return Ok(parents);
        }
        // GET: api/Parent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentDTO>> GetParent(int id)
        {
            var parent = await _repository.GetByIdAsync(id);
            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }
        // POST: api/Parent
        [HttpPost]
        [Authorize(Roles = "teacher")]
        public async Task<ActionResult<ParentDTO>> CreateParent(ParentDTO parentDto)
        {
            try
            {
                var createdParent = await _repository.CreateAsync(parentDto);
                return createdParent;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Parent/5
        [HttpPut("{id}")]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> UpdateParent(int id, ParentDTO parentDto)
        {
            if (id <= 0 || parentDto == null)
            {
                return BadRequest("Invalid ID or parent data provided.");
            }
            try
            {
                var updatedParent = await _repository.UpdateAsync(id, parentDto);
                return Ok(updatedParent);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Parent/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent(); // 204 No Content
        }

    }
}
