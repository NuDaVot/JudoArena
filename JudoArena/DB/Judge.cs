using System;
using System.Collections.Generic;

namespace JudoArena.bd;

public partial class Judge
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Category { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Competition> Competitions { get; set; } = new List<Competition>();

    public virtual ICollection<Meet> Meets { get; set; } = new List<Meet>();
}
