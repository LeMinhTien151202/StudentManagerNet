using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;

namespace StudentManager.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;
        public ClassRepository(TimetestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClassDTO> CreateClassAsync(ClassDTO classDto)
        {
            var newClass = _mapper.Map<Class>(classDto);
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            var createdClassDto = _mapper.Map<ClassDTO>(newClass);
            return createdClassDto;
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null)
            {
                return false; // or throw an exception based on your design choice
            }
            _context.Classes.Remove(classEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClassDTO>> GetAllClassesAsync()
        {
           var classes = await _context.Classes.ToListAsync();
            return classes.Select(c => _mapper.Map<ClassDTO>(c));
            //return classes; // Assuming you want to return the Class entities directly
        }

        public async Task<ClassDTO?> GetClassByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null)
            {
                return null; // or throw an exception based on your design choice
            }
            return _mapper.Map<ClassDTO>(classEntity);
        }

        public async Task<ClassDTO> UpdateClassAsync(int id, ClassDTO classDto)
        {
            if (id <= 0 || classDto == null)
            {
                throw new ArgumentException("Invalid ID or class data provided.", nameof(id));
            }
            var existingClass = await _context.Classes.FindAsync(id);
            if (existingClass == null)
            {
                throw new KeyNotFoundException($"Class with ID {id} not found.");
            }
            _mapper.Map(classDto, existingClass);
            _context.Classes.Update(existingClass);
            await _context.SaveChangesAsync();
            var updatedClassDto = _mapper.Map<ClassDTO>(existingClass);
            return updatedClassDto;
        }
    }
}
