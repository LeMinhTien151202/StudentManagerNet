using System;
using System.Collections.Generic;

namespace StudentManager.Models;

public partial class User
{
    public int Id { get; set; }

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

    public virtual Class? Class { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    public virtual Role Role { get; set; } = null!;

    public virtual Subject? Subject { get; set; }
}
