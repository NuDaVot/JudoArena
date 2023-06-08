using System;
using System.Collections.Generic;

namespace JudoArena.Model.DB;

public partial class Trainer : UserInterface
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? LicenseNumber { get; set; }

    public int? LoginTrainer { get; set; }

    public virtual Login? LoginTrainerNavigation { get; set; }

    public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; } = new List<ParticipantCategory>();
}
