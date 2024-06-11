using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMIAS.Models;

public partial class EmiasContext : DbContext
{
    public EmiasContext()
    {
    }

    public EmiasContext(DbContextOptions<EmiasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AnalysDocument> AnalysDocuments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentDocument> AppointmentDocuments { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<ResearchDocument> ResearchDocuments { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admin___69F56766E097E0A8");

            entity.ToTable("Admin_");

            entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");
            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.SurnameAdmin).HasMaxLength(50);
        });

        modelBuilder.Entity<AnalysDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__AnalysDo__CE24CCCC79986845");

            entity.ToTable("AnalysDocument");

            entity.Property(e => e.IdAppointment)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Appointment");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__CE24CCCCBD652A55");

            entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
        });

        modelBuilder.Entity<AppointmentDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__CE24CCCCFB8CCF47");

            entity.ToTable("AppointmentDocument");

            entity.Property(e => e.IdAppointment)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Appointment");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PK__Directio__59A79AAFB5DF7582");

            entity.Property(e => e.IdDirection).HasColumnName("ID_Direction");
            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctor__3246951CDEE6332C");

            entity.ToTable("Doctor");

            entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");
            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FirstName_");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.WorkAddress).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Oms).HasName("PK__Patient__CB396B8B68A6A722");

            entity.ToTable("Patient");

            entity.Property(e => e.Oms)
                .ValueGeneratedNever()
                .HasColumnName("OMS");
            entity.Property(e => e.AddressPatient).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LivingAddress).HasMaxLength(255);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(18);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<ResearchDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Research__CE24CCCCEFE43D52");

            entity.ToTable("ResearchDocument");

            entity.Property(e => e.IdAppointment)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Appointment");
            entity.Property(e => e.Attachment).HasMaxLength(1);
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality).HasName("PK__Speciali__8D22304D034DA580");

            entity.Property(e => e.IdSpeciality).HasColumnName("ID_Speciality");
            entity.Property(e => e.NameSpecialities).HasMaxLength(50);
            entity.Property(e => e.PathImage).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Status__5AC2A734401E5793");

            entity.ToTable("Status");

            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.NameStatus).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
