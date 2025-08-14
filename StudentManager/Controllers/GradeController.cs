using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Dtos;
using StudentManager.Repositories;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _repository;
            public GradeController(IGradeRepository repository)
            {
                _repository = repository;
            }
    
            // GET: api/Grade
            [HttpGet]
            public async Task<ActionResult<IEnumerable<GradeDTO>>> GetGrades()
            {
                var grades = await _repository.GetAllAsync();
                return Ok(grades);
            }
    
            // GET: api/Grade/5
            [HttpGet("{id}")]
            public async Task<ActionResult<GradeDTO>> GetGrade(int id)
            {
                var grade = await _repository.GetByIdAsync(id);
                if (grade == null)
                {
                    return NotFound();
                }
                return Ok(grade);
            }
    
            // POST: api/Grade
            [HttpPost]
            [Authorize(Roles = "teacher")]    
            public async Task<ActionResult<GradeDTO>> CreateGrade(GradeDTO gradeDto)
            {
                try
                {
                    var createdGrade = await _repository.CreateAsync(gradeDto);
                    return createdGrade;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    
            // PUT: api/Grade/5
            [HttpPut("{id}")]
            [Authorize(Roles = "teacher")]
            public async Task<IActionResult> UpdateGrade(int id, GradeDTO gradeDto)
            {
                if (id <= 0 || gradeDto == null)
                {
                    return BadRequest("Invalid ID or grade data provided.");
                }
                try
                {
                    var updatedGrade = await _repository.UpdateAsync(id, gradeDto);
                    if (updatedGrade == null)
                    {
                        return NotFound();
                    }
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    
            // DELETE: api/Grade/5
            [HttpDelete("{id}")]
            [Authorize(Roles = "teacher")]
            public async Task<IActionResult> DeleteGrade(int id)
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID provided.");
                }
                try
                {
                    var deleted = await _repository.DeleteAsync(id);
                    if (!deleted)
                    {
                        return NotFound();
                    }
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }
    }
}
