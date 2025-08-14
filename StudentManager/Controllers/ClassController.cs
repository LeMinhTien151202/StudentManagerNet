using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Dtos;
using StudentManager.Models;
using StudentManager.Repositories;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _repository;
        public ClassController(IClassRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetClasses()
        {
            var classes = await _repository.GetAllClassesAsync();
            return Ok(classes);
        }
        // GET: api/Class/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDTO>> GetClass(int id)
        {
            var classEntity = await _repository.GetClassByIdAsync(id);
            if (classEntity == null)
            {
                return NotFound();
            }
            return Ok(classEntity);
        }
        // POST: api/Class
        [HttpPost]
        public async Task<ActionResult<ClassDTO>> CreateClass(ClassDTO classDto)
        {
            try
            {
                var createdClass = await _repository.CreateClassAsync(classDto);
                return CreatedAtAction(nameof(GetClass), new { id = createdClass.Id }, createdClass);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Class/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, ClassDTO classDto)
        {
            if (id <= 0 || classDto == null)
            {
                return BadRequest("Invalid ID or class data provided.");
            }
            try
            {
                var updatedClass = await _repository.UpdateClassAsync(id, classDto);
                if (updatedClass == null)
                {
                    return NotFound();
                }
                return NoContent(); // or return Ok(updatedClass) if you want to return the updated object
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Class/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }
            try
            {
                var result = await _repository.DeleteClassAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent(); // or return Ok() if you want to return a success message
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
    }
}
