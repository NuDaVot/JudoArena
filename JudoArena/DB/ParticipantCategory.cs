using System;
using System.Collections.Generic;

namespace JudoArena.DB;

public partial class ParticipantCategory
{
    public int Id { get; set; }

    public int? IdParticipant { get; set; }

    public int? IdCategory { get; set; }

    public int? IdTrainer { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Participant? IdParticipantNavigation { get; set; }

    public virtual Trainer? IdTrainerNavigation { get; set; }

    public virtual ICollection<Meet> MeetIdBlueNavigations { get; set; } = new List<Meet>();

    public virtual ICollection<Meet> MeetIdWhiteNavigations { get; set; } = new List<Meet>();
}
