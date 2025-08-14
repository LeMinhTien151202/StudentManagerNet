namespace StudentManager.Dtos
{
    public class YourEntityDTO
    {
        public string Name { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? ExpiredAt { get; set; }
    }
}
