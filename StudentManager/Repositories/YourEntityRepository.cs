using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace StudentManager.Repositories
{
    public class YourEntityRepository : IYourEntityRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;

        public YourEntityRepository(TimetestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<YourEntityDTO>> GetAllAsync()
        {
            var entities = await _context.YourEntities.ToListAsync();
            return entities.Select(e => _mapper.Map<YourEntityDTO>(e));
        }
        public async Task<YourEntityDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.YourEntities.FindAsync(id);
            
            return _mapper.Map<YourEntityDTO>(entity);
        }
        public async Task<YourEntityDTO> CreateAsync(YourEntityDTO entityDto)
        {
            var newEntity = _mapper.Map<YourEntity>(entityDto);
            await _context.YourEntities.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            var createdEntityDto = _mapper.Map<YourEntityDTO>(newEntity);
            return createdEntityDto;

        }
        public async Task<YourEntityDTO> UpdateAsync(int id, YourEntityDTO entityDto)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var existingEntity = _context.YourEntities.Find(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            var updatedEntity = _mapper.Map(entityDto, existingEntity);
            _context.YourEntities.Update(updatedEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<YourEntityDTO>(updatedEntity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.YourEntities.FindAsync(id);
            if (entity == null)
            {
                return false; // Entity not found
            }
            _context.YourEntities.Remove(entity);
            await _context.SaveChangesAsync();
            return true; // Entity deleted successfully'
        }
    }
}
