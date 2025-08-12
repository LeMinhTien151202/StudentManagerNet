using System;
using System.Collections.Generic;

namespace StudentManager.Models;

public partial class Parent
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Relationship { get; set; }

    public int UserId { get; set; }

    public string? Email { get; set; }

    public virtual User User { get; set; } = null!;
}
