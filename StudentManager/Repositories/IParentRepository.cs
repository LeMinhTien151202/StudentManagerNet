using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<ParentDTO>> GetAllAsync();
        Task<ParentDTO?> GetByIdAsync(int id);
        Task<ParentDTO> CreateAsync(ParentDTO parentDto);
        Task<ParentDTO> UpdateAsync(int id, ParentDTO parentDto);
        Task<bool> DeleteAsync(int id);
    }
}
