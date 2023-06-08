using System;
using System.Collections.Generic;

namespace JudoArena.Model.DB;

public partial class Participant : UserInterface
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public decimal? Weight { get; set; }

    public DateOnly? DateBirth { get; set; }

    public int? HealthInsuranceNumber { get; set; }

    public int? LoginParticipant { get; set; }

    public virtual Login? LoginParticipantNavigation { get; set; }

    public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; } = new List<ParticipantCategory>();
}
