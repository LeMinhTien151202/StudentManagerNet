using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradeDTO>> GetAllAsync();
        Task<GradeDTO?> GetByIdAsync(int id);
        Task<GradeDTO> CreateAsync(GradeDTO gradeDto);
        Task<GradeDTO> UpdateAsync(int id, GradeDTO gradeDto);
        Task<bool> DeleteAsync(int id);
    }
}
