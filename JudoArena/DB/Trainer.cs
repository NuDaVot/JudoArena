using System;
using System.Collections.Generic;

namespace JudoArena.bd;

public partial class Trainer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public int? LicenseNumber { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; } = new List<ParticipantCategory>();
}
