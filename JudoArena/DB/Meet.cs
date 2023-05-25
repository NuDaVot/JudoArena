using System;
using System.Collections.Generic;

namespace JudoArena.bd;

public partial class Meet
{
    public int Id { get; set; }

    public TimeOnly? Duration { get; set; }

    public string? Assessments { get; set; }

    public bool? Result { get; set; }

    public int? IdWhite { get; set; }

    public int? IdBlue { get; set; }

    public int? IdJudge { get; set; }

    public int? IdCategory { get; set; }

    public virtual ParticipantCategory? IdBlueNavigation { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Judge? IdJudgeNavigation { get; set; }

    public virtual ParticipantCategory? IdWhiteNavigation { get; set; }
}
