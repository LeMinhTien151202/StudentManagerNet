using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using StudentManager.Dtos;
using StudentManager.Models;
using StudentManager.Services;

namespace StudentManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public UserRepository(TimetestContext context, IMapper mapper, TokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<UserRegisterDTO> CreateUserAsync(UserRegisterDTO userDto)
        {
           var newUser = _mapper.Map<User>(userDto);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            var createdUserDto = _mapper.Map<UserRegisterDTO>(newUser);
            return createdUserDto;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false; // or throw an exception based on your design choice
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserRegisterDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => _mapper.Map<UserRegisterDTO>(u));
        }

        public async Task<string?> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Code == userLoginDTO.Code);

            if (user == null)
                return null;

            // So sánh mật khẩu
            if (!BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, user.Password))
                return null;

            // Tạo token và trả về nếu xác thực thành công
            return _tokenService.CreateToken(user);
        }

        public async Task<string?> RegisterAsync(UserRegisterDTO dto)
        {
            if (await _context.Users.AnyAsync(u => u.Code == dto.Code))
                return "Code already exists.";

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Code = dto.Code,
                Address = dto.Address,
                Gender= dto.Gender,
                ClassId = dto.ClassId,
                SubjectId = dto.SubjectId,
                Password = passwordHash,
                PhoneNumber = dto.PhoneNumber,
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User registered successfully.";
        }

        public async Task<UserRegisterDTO?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) {
                return null; // or throw an exception based on your design choice   
            }
            return _mapper.Map<UserRegisterDTO>(user);
        }

        public async Task<UserRegisterDTO> UpdateUserAsync(int id, UserRegisterDTO userDto)
        {
            if (id <= 0 || userDto == null)
            {
                throw new ArgumentException("Invalid ID or user data provided.", nameof(id));
            }
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");

            }
            _mapper.Map(userDto, existingUser);
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserRegisterDTO>(existingUser);
        }
    }
}
