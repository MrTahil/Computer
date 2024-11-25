using System;
using System.Collections.Generic;

namespace ComputerApi.Models;

public partial class Comp
{
    public string Id { get; set; } = null!;

    public string? Brand { get; set; }

    public string? Type { get; set; }

    public double? Display { get; set; }

    public int? Memory { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? OsId { get; set; }

    public virtual Osystem? Os { get; set; }
}
