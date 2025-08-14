namespace StudentManager.Dtos
{
    public class UserRegisterDTO
    {
        public string Code { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public int? ClassId { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public int RoleId { get; set; }

        public string? AvatarUrl { get; set; }

        public string Password { get; set; } = null!;

        public int? SubjectId { get; set; }
    }
}
