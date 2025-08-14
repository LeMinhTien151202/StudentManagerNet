using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;

namespace StudentManager.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;
        public SubjectRepository(TimetestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SubjectDTO> CreateAsync(SubjectDTO subjectDto)
        {
            var newSubject = _mapper.Map<Subject>(subjectDto);
            await _context.Subjects.AddAsync(newSubject);
            await _context.SaveChangesAsync();
            var createdSubjectDto = _mapper.Map<SubjectDTO>(newSubject);
            return createdSubjectDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return false; 
            }
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return subjects.Select(s => _mapper.Map<SubjectDTO>(s));
        }

        public async Task<SubjectDTO?> GetByIdAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return null; // or throw an exception based on your design choice
            }
            return _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<SubjectDTO> UpdateAsync(int id, SubjectDTO subjectDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var existingSubject = await _context.Subjects.FindAsync(id);
            if (existingSubject == null)
            {
                throw new KeyNotFoundException($"Subject with ID {id} not found.");
            }
            var updatedSubject = _mapper.Map(subjectDto, existingSubject);
            _context.Subjects.Update(updatedSubject);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubjectDTO>(updatedSubject);
        }
    }
}
