using System;
using System.Collections.Generic;

namespace StudentManager.Models;

public partial class YourEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ExpiredAt { get; set; }
}
