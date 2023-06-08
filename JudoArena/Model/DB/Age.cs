using System;
using System.Collections.Generic;

namespace JudoArena.Model.DB;

public partial class Age
{
    public int Id { get; set; }

    public DateOnly? AgeStart { get; set; }

    public DateOnly? AgeEnd { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
