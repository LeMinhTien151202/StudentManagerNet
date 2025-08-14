using StudentManager.Models;

namespace StudentManager.Dtos
{
    public class GradeDTO
    {
        public int UserId { get; set; }

        public int SubjectId { get; set; }

        public string SchoolYear { get; set; } = null!;

        public int Semester { get; set; }

        public float? OralScore { get; set; }

        public float? FifteenScore { get; set; }

        public float? OnePeriodScore { get; set; }

        public float? ExamScore { get; set; }

    }
}
