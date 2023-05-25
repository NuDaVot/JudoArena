using System;
using System.Collections.Generic;

namespace JudoArena.bd;

public partial class Participant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public decimal? Weight { get; set; }

    public DateOnly? DateBirth { get; set; }

    public int? HealthInsuranceNumber { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; } = new List<ParticipantCategory>();
}
