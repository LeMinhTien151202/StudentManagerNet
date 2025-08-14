namespace StudentManager.Dtos
{
    public class ParentDTO
    {
        public string FullName { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Relationship { get; set; }

        public int UserId { get; set; }

        public string? Email { get; set; }
    }
}
