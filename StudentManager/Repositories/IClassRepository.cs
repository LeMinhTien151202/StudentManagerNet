using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<ClassDTO>> GetAllClassesAsync();
        Task<ClassDTO?> GetClassByIdAsync(int id);
        Task<ClassDTO> CreateClassAsync(ClassDTO classDto);
        Task<ClassDTO> UpdateClassAsync(int id, ClassDTO classDto);
        Task<bool> DeleteClassAsync(int id);
    }
}
