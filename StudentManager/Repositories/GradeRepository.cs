using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;

namespace StudentManager.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;
        public GradeRepository(TimetestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GradeDTO> CreateAsync(GradeDTO gradeDto)
        {
            var newGrade = _mapper.Map<Grade>(gradeDto);
            await _context.Grades.AddAsync(newGrade);
            await _context.SaveChangesAsync();
            var createdGradeDto = _mapper.Map<GradeDTO>(newGrade);
            return createdGradeDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return false; // or throw an exception based on your design choice
            }
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GradeDTO>> GetAllAsync()
        {
            var grades = await _context.Grades.ToListAsync();
            return grades.Select(g => _mapper.Map<GradeDTO>(g));
        }

        public async Task<GradeDTO?> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return null; // or throw an exception based on your design choice
            }
            return _mapper.Map<GradeDTO>(grade);
        }

        public async Task<GradeDTO> UpdateAsync(int id, GradeDTO gradeDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var existingGrade = await _context.Grades.FindAsync(id);
            if (existingGrade == null)
            {
                throw new KeyNotFoundException($"Grade with ID {id} not found.");
            }
            _mapper.Map(gradeDto, existingGrade);
            _context.Grades.Update(existingGrade);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradeDTO>(existingGrade);
        }
    }
}
