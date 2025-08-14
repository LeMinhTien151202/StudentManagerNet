using StudentManager.Models;

namespace StudentManager.Dtos
{
    public class ClassDTO
    {
        public int Id { get; set; }

        public string ClassName { get; set; } = null!;

        public string SchoolYear { get; set; } = null!;

        public int? UserId { get; set; }

    }
}
