using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<SubjectDTO>> GetAllAsync();
        Task<SubjectDTO?> GetByIdAsync(int id);
        Task<SubjectDTO> CreateAsync(SubjectDTO subjectDto);
        Task<SubjectDTO> UpdateAsync(int id, SubjectDTO subjectDto);
        Task<bool> DeleteAsync(int id);
    }
}
