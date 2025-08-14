using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Dtos;
using StudentManager.Repositories;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IYourEntityRepository _repository;
        public EntityController(IYourEntityRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Entity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YourEntityDTO>>> GetEntities()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }
        // GET: api/Entity/5
        [HttpGet("{id}")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<YourEntityDTO>> GetEntity(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        // POST: api/Entity
        [HttpPost]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<YourEntityDTO>> CreateEntity(YourEntityDTO entityDto)
        {
            try
            {
                var createdEntity = await _repository.CreateAsync(entityDto);
                return createdEntity;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Entity/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateEntity(int id, YourEntityDTO entityDto)
        {
            if (id <= 0 || entityDto == null)
            {
                return BadRequest("Invalid ID or entity data provided.");
            }
            var updatedEntity = await _repository.UpdateAsync(id, entityDto);
            return Ok(updatedEntity);
        }
        // DELETE: api/Entity/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
