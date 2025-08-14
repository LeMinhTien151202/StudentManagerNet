using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface IRoleRepository
    {
        // Define methods for role management, e.g.:
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleByIdAsync(int id);
        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto);
        Task<RoleDTO> UpdateRoleAsync(int id, RoleDTO roleDto);
        Task<bool> DeleteRoleAsync(int id);
    }
}
