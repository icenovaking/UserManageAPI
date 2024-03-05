using System;
using System.Collections.Generic;

namespace UserManageAPI.Models;

public partial class CityInfo
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public string? Province { get; set; }
}
