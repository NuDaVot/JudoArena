using System;
using System.Collections.Generic;

namespace JudoArena.DB;

public partial class Weight
{
    public int Id { get; set; }

    public decimal? WeightStart { get; set; }

    public decimal? WeightEnd { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
