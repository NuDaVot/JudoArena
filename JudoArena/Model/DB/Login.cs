using System;
using System.Collections.Generic;

namespace JudoArena.Model.DB;

public partial class Login
{
    public int Id { get; set; }

    public string? Loggin { get; set; }

    public string? Password { get; set; }

    /// <summary>
    /// 0 - участник\\n1 - тренер \\n2 - судья
    /// </summary>
    public int? Role { get; set; }

    public virtual ICollection<Judge> Judges { get; set; } = new List<Judge>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
}
