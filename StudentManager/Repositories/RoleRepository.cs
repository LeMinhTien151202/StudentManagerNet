using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManager.Dtos;
using StudentManager.Models;

namespace StudentManager.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TimetestContext _context;
        private readonly IMapper _mapper;
        public RoleRepository(TimetestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto)
        {
            var newRole = _mapper.Map<Role>(roleDto);
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();
            var createdRoleDto = _mapper.Map<RoleDTO>(newRole);
            return createdRoleDto;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return false; // or throw an exception based on your design choice
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Select(r => _mapper.Map<RoleDTO>(r));
        }

        public async Task<RoleDTO?> GetRoleByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return null; // or throw an exception based on your design choice
            }
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> UpdateRoleAsync(int id, RoleDTO roleDto)
        {
            var existingRole = await _context.Roles.FindAsync(id);
            if (existingRole == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided.", nameof(id));
            }
            _mapper.Map(roleDto, existingRole);
            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync();
            return _mapper.Map<RoleDTO>(existingRole);
        }
    }
}
