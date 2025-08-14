using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;

namespace StudentManager.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;
        public ParentRepository(TimetestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ParentDTO> CreateAsync(ParentDTO parentDto)
        {
            var newParent = _mapper.Map<Parent>(parentDto);
            await _context.Parents.AddAsync(newParent);
            await _context.SaveChangesAsync();
            var createdParentDto = _mapper.Map<ParentDTO>(newParent);
            return createdParentDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null)
            {
                return false; // or throw an exception based on your design choice
            }
            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ParentDTO>> GetAllAsync()
        {
            var parents = await _context.Parents.ToListAsync();
            return parents.Select(p => _mapper.Map<ParentDTO>(p));
        }

        public async Task<ParentDTO?> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null)
            {
                return null; // or throw an exception based on your design choice
            }
            return _mapper.Map<ParentDTO>(parent);
        }

        public async Task<ParentDTO> UpdateAsync(int id, ParentDTO parentDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var existingParent = await _context.Parents.FindAsync(id);
            if (existingParent == null)
            {
                throw new KeyNotFoundException($"Parent with ID {id} not found.");
            }
            _mapper.Map(parentDto, existingParent);
            _context.Parents.Update(existingParent);
            await _context.SaveChangesAsync();
            return _mapper.Map<ParentDTO>(existingParent);
        }
    }
}
