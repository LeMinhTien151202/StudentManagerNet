using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface IYourEntityRepository
    {
        Task<IEnumerable<YourEntityDTO>> GetAllAsync();
        Task<YourEntityDTO?> GetByIdAsync(int id);
        Task<YourEntityDTO> CreateAsync(YourEntityDTO entityDto);
        Task<YourEntityDTO> UpdateAsync(int id, YourEntityDTO entityDto);
        Task<bool> DeleteAsync(int id);
    }
}
