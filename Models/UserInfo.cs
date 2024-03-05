using System;
using System.Collections.Generic;

namespace UserManageAPI.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public double? Age { get; set; }

    public int? Sex { get; set; }

    public string? Location { get; set; }
}
