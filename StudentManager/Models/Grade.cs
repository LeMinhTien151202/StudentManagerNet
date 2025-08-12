using System;
using System.Collections.Generic;

namespace StudentManager.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SubjectId { get; set; }

    public string SchoolYear { get; set; } = null!;

    public int Semester { get; set; }

    public float? OralScore { get; set; }

    public float? FifteenScore { get; set; }

    public float? OnePeriodScore { get; set; }

    public float? ExamScore { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
