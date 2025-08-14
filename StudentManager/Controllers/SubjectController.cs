using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Dtos;
using StudentManager.Repositories;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _repository;
        public SubjectController(ISubjectRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetSubjects()
        {
            var subjects = await _repository.GetAllAsync();
            return Ok(subjects);
        }
        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDTO>> GetSubject(int id)
        {
            var subject = await _repository.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }
        // POST: api/Subject
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<SubjectDTO>> CreateSubject(SubjectDTO subjectDto)
        {
            try
            {
                var createdSubject = await _repository.CreateAsync(subjectDto);
                return createdSubject;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Subject/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateSubject(int id, SubjectDTO subjectDto)
        {
            if (id <= 0 || subjectDto == null)
            {
                return BadRequest("Invalid ID or subject data provided.");
            }
            try
            {
                var updatedSubject = await _repository.UpdateAsync(id, subjectDto);
                return Ok(updatedSubject);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Subject with ID {id} not found.");
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Subject with ID {id} not found.");
            }
            return NoContent(); // 204 No Content
        }
    }
}
