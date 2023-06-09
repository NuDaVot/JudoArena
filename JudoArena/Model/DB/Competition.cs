﻿
using System.ComponentModel.DataAnnotations;

namespace JudoArena.Model.DB;

public partial class Competition
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Date { get; set; }

    public string? Address { get; set; }

    public int? Organizer { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual Judge? OrganizerNavigation { get; set; }
}
