using System;
using System.Collections.Generic;

namespace ComputerApi.Models;

public partial class Osystem
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Comp> Comps { get; set; } = new List<Comp>();
}
