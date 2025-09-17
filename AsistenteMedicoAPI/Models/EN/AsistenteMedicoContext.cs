using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AsistenteMedicoAPI.Models.EN;

public partial class AsistenteMedicoContext : DbContext
{
    public AsistenteMedicoContext()
    {
    }

    public AsistenteMedicoContext(DbContextOptions<AsistenteMedicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CentroMedico> Centrosmedicos { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Especialidad> Especialidades { get; set; }

    public virtual DbSet<Horariosmedico> Horariosmedicos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<MedicoEspecialidad> Medicoespecialidades { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TiposCita> Tiposcita { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CentroMedico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("centrosmedicos");

            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EstaActivo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.HorarioFin)
                .HasDefaultValueSql("'18:00:00'")
                .HasColumnType("time");
            entity.Property(e => e.HorarioInicio)
                .HasDefaultValueSql("'08:00:00'")
                .HasColumnType("time");
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.SitioWeb).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("citas");

            entity.HasIndex(e => e.CentroId, "CentroId");

            entity.HasIndex(e => e.MedicoId, "MedicoId");

            entity.HasIndex(e => e.PacienteId, "PacienteId");

            entity.HasIndex(e => e.TipoCitaId, "TipoCitaId");

            entity.Property(e => e.CreadaPor)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Sistema'");
            entity.Property(e => e.EstaPagada).HasDefaultValueSql("'0'");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Agendada'")
                .HasColumnType("enum('Agendada','Confirmada','En_Curso','Completada','Cancelada','No_Show')");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.HoraFin).HasColumnType("time");
            entity.Property(e => e.HoraInicio).HasColumnType("time");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.Motivo).HasMaxLength(300);
            entity.Property(e => e.Notas).HasColumnType("text");
            entity.Property(e => e.NotasMedicas).HasColumnType("text");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");

            entity.HasOne(d => d.Centro).WithMany(p => p.Cita)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citas_ibfk_1");

            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citas_ibfk_3");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citas_ibfk_2");

            entity.HasOne(d => d.TipoCita).WithMany(p => p.Cita)
                .HasForeignKey(d => d.TipoCitaId)
                .HasConstraintName("citas_ibfk_4");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("especialidades");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Color)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#0066CC'");
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.DuracionPredeterminadaMinutos).HasDefaultValueSql("'30'");
            entity.Property(e => e.EstaActivo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Horariosmedico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("horariosmedicos");

            entity.HasIndex(e => e.MedicoId, "MedicoId");

            entity.Property(e => e.EstaActivo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.HoraFin).HasColumnType("time");
            entity.Property(e => e.HoraInicio).HasColumnType("time");

            entity.HasOne(d => d.Medico).WithMany(p => p.Horariosmedicos)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("horariosmedicos_ibfk_1");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicos");

            entity.HasIndex(e => e.CentroId, "CentroId");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Biografia).HasColumnType("text");
            entity.Property(e => e.CitasDiariasMax).HasDefaultValueSql("'20'");
            entity.Property(e => e.DuracionCitaPredeterminada).HasDefaultValueSql("'30'");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EstaActivo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ImagenPerfil).HasMaxLength(500);
            entity.Property(e => e.NumeroLicencia).HasMaxLength(50);
            entity.Property(e => e.PermitirReservaEnLinea).HasDefaultValueSql("'1'");
            entity.Property(e => e.PrimerNombre).HasMaxLength(100);
            entity.Property(e => e.TarifaConsulta)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Centro).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicos_ibfk_1");
        });

        modelBuilder.Entity<MedicoEspecialidad>(entity =>
        {
            entity.HasKey(e => new { e.MedicoId, e.EspecialidadId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("medicoespecialidades");

            entity.HasIndex(e => e.EspecialidadId, "EspecialidadId");

            entity.Property(e => e.EsPrincipal).HasDefaultValueSql("'0'");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.Medicoespecialidades)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicoespecialidades_ibfk_2");

            entity.HasOne(d => d.Medico).WithMany(p => p.Medicoespecialidades)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("medicoespecialidades_ibfk_1");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.CentroId, "CentroId");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.ContactoEmergencia).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EstaActivo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Genero).HasColumnType("enum('M','F','Otro')");
            entity.Property(e => e.NumeroPaciente).HasMaxLength(10);
            entity.Property(e => e.PrimerNombre).HasMaxLength(100);
            entity.Property(e => e.RecibirEmail).HasDefaultValueSql("'1'");
            entity.Property(e => e.RecibirSms).HasDefaultValueSql("'1'");
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TelefonoEmergencia).HasMaxLength(20);
            entity.Property(e => e.UltimaVisita).HasColumnType("timestamp");

            entity.HasOne(d => d.Centro).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pacientes_ibfk_1");
        });

        modelBuilder.Entity<TiposCita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tiposcita");

            entity.HasIndex(e => e.CentroId, "CentroId");

            entity.Property(e => e.Color)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#0066CC'");
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.DuracionMinutos).HasDefaultValueSql("'30'");
            entity.Property(e => e.EstaActivo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");

            entity.HasOne(d => d.Centro).WithMany(p => p.Tiposcita)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tiposcita_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
