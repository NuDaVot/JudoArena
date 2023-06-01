using System;
using System.Collections.Generic;
using JudoArena.DB;

namespace JudoArena;

public partial class Age
{
    public int Id { get; set; }

    public DateOnly? AgeStart { get; set; }

    public DateOnly? AgeEnd { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
