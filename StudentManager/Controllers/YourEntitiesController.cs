using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;

namespace StudentManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YourEntitiesController : ControllerBase
    {
        private readonly TimetestContext _context;

        public YourEntitiesController(TimetestContext context)
        {
            _context = context;
        }

        // GET: api/YourEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YourEntityDTO>>> GetYourEntities()
        {
            // Fetch all entities and map them to DTOs
            var entities = await _context.YourEntities.ToListAsync();
            var entityDTOs = entities.Select(e => new YourEntityDTO
            {
                Name = e.Name,
                CreatedAt =  e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
                ExpiredAt = e.ExpiredAt
            }).ToList();

            return entityDTOs;
        }

        // GET: api/YourEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YourEntityDTO>> GetYourEntity(long id)
        {
            // Fetch the entity by ID and map it to a DTO
            if (id <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }
            var yourEntity = await _context.YourEntities.FindAsync(id);
            var yourEntityDTO = new YourEntityDTO
            {
                Name = yourEntity?.Name,
                CreatedAt = yourEntity?.CreatedAt,
                UpdatedAt = yourEntity?.UpdatedAt,
                ExpiredAt = yourEntity?.ExpiredAt
            };
            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntityDTO;
        }

        // PUT: api/YourEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(long id, YourEntity yourEntity)
        {
            if (id != yourEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(yourEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YourEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/YourEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YourEntityDTO>> PostYourEntity(YourEntityDTO yourEntityDTO)
        {
            var yourEntity = new YourEntity
            {
                Name = yourEntityDTO.Name,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = yourEntityDTO.ExpiredAt
            };
            _context.YourEntities.Add(yourEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYourEntity", new { id = yourEntity.Id }, yourEntity);
        }

        // DELETE: api/YourEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYourEntity(long id)
        {
            var yourEntity = await _context.YourEntities.FindAsync(id);
            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.YourEntities.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(long id)
        {
            return _context.YourEntities.Any(e => e.Id == id);
        }
    }
}
