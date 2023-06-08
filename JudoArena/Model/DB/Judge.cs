using System;
using System.Collections.Generic;

namespace JudoArena.Model.DB;

public partial class Judge : UserInterface
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Category { get; set; }

    public int? LoginJudges { get; set; }

    public virtual ICollection<Competition> Competitions { get; set; } = new List<Competition>();

    public virtual Login? LoginJudgesNavigation { get; set; }

    public virtual ICollection<Meet> Meets { get; set; } = new List<Meet>();
}
