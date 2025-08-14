using StudentManager.Dtos;

namespace StudentManager.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserRegisterDTO>> GetAllUsersAsync();
        Task<UserRegisterDTO?> GetUserByIdAsync(int id);
        Task<string?> LoginAsync(UserLoginDTO userLoginDTO);
        Task<string?> RegisterAsync(UserRegisterDTO dto);
        Task<UserRegisterDTO> CreateUserAsync(UserRegisterDTO userDto);
        Task<UserRegisterDTO> UpdateUserAsync(int id, UserRegisterDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
