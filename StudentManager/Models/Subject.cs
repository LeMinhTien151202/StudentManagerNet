using System;
using System.Collections.Generic;

namespace StudentManager.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
