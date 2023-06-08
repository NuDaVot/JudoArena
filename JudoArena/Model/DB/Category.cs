using System;
using System.Collections.Generic;

namespace JudoArena.Model.DB;

public partial class Category
{
    public int Id { get; set; }

    public int? IdCompetition { get; set; }

    public int? IdWeight { get; set; }

    public int? IdAge { get; set; }

    public virtual Age? IdAgeNavigation { get; set; }

    public virtual Competition? IdCompetitionNavigation { get; set; }

    public virtual Weight? IdWeightNavigation { get; set; }

    public virtual ICollection<Meet> Meets { get; set; } = new List<Meet>();

    public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; } = new List<ParticipantCategory>();
}
