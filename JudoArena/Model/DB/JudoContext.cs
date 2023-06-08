using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JudoArena.Model.DB;

public partial class JudoContext : DbContext
{
    public JudoContext()
    {
    }

    public JudoContext(DbContextOptions<JudoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Age> Ages { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Judge> Judges { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Meet> Meets { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<ParticipantCategory> ParticipantCategories { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<Weight> Weights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=judo", ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Age>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("age");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AgeEnd).HasColumnName("age_end");
            entity.Property(e => e.AgeStart).HasColumnName("age_start");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.HasIndex(e => e.IdAge, "FK_id_age_idx");

            entity.HasIndex(e => e.IdCompetition, "FK_id_competition_idx");

            entity.HasIndex(e => e.IdWeight, "FK_id_weight_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdAge).HasColumnName("id_age");
            entity.Property(e => e.IdCompetition).HasColumnName("id_competition");
            entity.Property(e => e.IdWeight).HasColumnName("id_weight");

            entity.HasOne(d => d.IdAgeNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IdAge)
                .HasConstraintName("FK_id_age");

            entity.HasOne(d => d.IdCompetitionNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IdCompetition)
                .HasConstraintName("FK_id_competition");

            entity.HasOne(d => d.IdWeightNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IdWeight)
                .HasConstraintName("FK_id_weight");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("competitions");

            entity.HasIndex(e => e.Organizer, "FK_judge_competition_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Organizer).HasColumnName("organizer");

            entity.HasOne(d => d.OrganizerNavigation).WithMany(p => p.Competitions)
                .HasForeignKey(d => d.Organizer)
                .HasConstraintName("FK_judge_competition");
        });

        modelBuilder.Entity<Judge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("judges");

            entity.HasIndex(e => e.LoginJudges, "FK_id_login_judges_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(45)
                .HasColumnName("category");
            entity.Property(e => e.LoginJudges).HasColumnName("login_judges");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");

            entity.HasOne(d => d.LoginJudgesNavigation).WithMany(p => p.Judges)
                .HasForeignKey(d => d.LoginJudges)
                .HasConstraintName("FK_id_login_judges");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Loggin)
                .HasMaxLength(45)
                .HasColumnName("loggin");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasComment("0 - участник\\\\n1 - тренер \\\\n2 - судья")
                .HasColumnName("role");
        });

        modelBuilder.Entity<Meet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("meet");

            entity.HasIndex(e => e.IdBlue, "FK_id_blue_idx");

            entity.HasIndex(e => e.IdCategory, "FK_id_category1_idx");

            entity.HasIndex(e => e.IdJudge, "FK_id_judge_idx");

            entity.HasIndex(e => e.IdWhite, "FK_id_white_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assessments)
                .HasColumnType("tinytext")
                .HasColumnName("assessments");
            entity.Property(e => e.Duration)
                .HasColumnType("time")
                .HasColumnName("duration");
            entity.Property(e => e.IdBlue).HasColumnName("id_blue");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdJudge).HasColumnName("id_judge");
            entity.Property(e => e.IdWhite).HasColumnName("id_white");
            entity.Property(e => e.Result).HasColumnName("result");

            entity.HasOne(d => d.IdBlueNavigation).WithMany(p => p.MeetIdBlueNavigations)
                .HasForeignKey(d => d.IdBlue)
                .HasConstraintName("FK_id_blue");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Meets)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_id_category1");

            entity.HasOne(d => d.IdJudgeNavigation).WithMany(p => p.Meets)
                .HasForeignKey(d => d.IdJudge)
                .HasConstraintName("FK_id_judge");

            entity.HasOne(d => d.IdWhiteNavigation).WithMany(p => p.MeetIdWhiteNavigations)
                .HasForeignKey(d => d.IdWhite)
                .HasConstraintName("FK_id_white");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("participants");

            entity.HasIndex(e => e.LoginParticipant, "FK_id_login_participant_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateBirth).HasColumnName("date_birth");
            entity.Property(e => e.HealthInsuranceNumber).HasColumnName("health_insurance_number");
            entity.Property(e => e.LoginParticipant).HasColumnName("login_participant");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.Weight)
                .HasPrecision(3)
                .HasColumnName("weight");

            entity.HasOne(d => d.LoginParticipantNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.LoginParticipant)
                .HasConstraintName("FK_id_login_participant");
        });

        modelBuilder.Entity<ParticipantCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("participant_category");

            entity.HasIndex(e => e.IdCategory, "FK_id_category_idx");

            entity.HasIndex(e => e.IdParticipant, "FK_id_participant_idx");

            entity.HasIndex(e => e.IdTrainer, "FK_id_trainer_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdParticipant).HasColumnName("id_participant");
            entity.Property(e => e.IdTrainer).HasColumnName("id_trainer");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.ParticipantCategories)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_id_category");

            entity.HasOne(d => d.IdParticipantNavigation).WithMany(p => p.ParticipantCategories)
                .HasForeignKey(d => d.IdParticipant)
                .HasConstraintName("FK_id_participant");

            entity.HasOne(d => d.IdTrainerNavigation).WithMany(p => p.ParticipantCategories)
                .HasForeignKey(d => d.IdTrainer)
                .HasConstraintName("FK_id_trainer");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trainer");

            entity.HasIndex(e => e.LoginTrainer, "FK_id_login_trainer_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LicenseNumber).HasColumnName("license_number");
            entity.Property(e => e.LoginTrainer).HasColumnName("login_trainer");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");

            entity.HasOne(d => d.LoginTrainerNavigation).WithMany(p => p.Trainers)
                .HasForeignKey(d => d.LoginTrainer)
                .HasConstraintName("FK_id_login_trainer");
        });

        modelBuilder.Entity<Weight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("weight");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.WeightEnd)
                .HasPrecision(3)
                .HasColumnName("weight_end");
            entity.Property(e => e.WeightStart)
                .HasPrecision(3)
                .HasColumnName("weight_start");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
