using System;
using System.Collections.Generic;

namespace StudentManager.Models;

public partial class Class
{
    public int Id { get; set; }

    public string ClassName { get; set; } = null!;

    public string SchoolYear { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
