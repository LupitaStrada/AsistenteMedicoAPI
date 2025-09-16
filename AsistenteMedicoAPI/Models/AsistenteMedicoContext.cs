using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AsistenteMedicoAPI.Models;

public partial class AsistenteMedicoContext : DbContext
{
    public AsistenteMedicoContext()
    {
    }

    public AsistenteMedicoContext(DbContextOptions<AsistenteMedicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CentrosMedico> CentrosMedicos { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Especialidades> Especialidades { get; set; }

    public virtual DbSet<HorariosMedico> HorariosMedicos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<MedicoEspecialidades> MedicoEspecialidades { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TiposCita> TiposCita { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CentrosMedico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("centros_medicos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.EstaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("esta_activo");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.HorarioFin)
                .HasDefaultValueSql("'18:00:00'")
                .HasColumnType("time")
                .HasColumnName("horario_fin");
            entity.Property(e => e.HorarioInicio)
                .HasDefaultValueSql("'08:00:00'")
                .HasColumnType("time")
                .HasColumnName("horario_inicio");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .HasColumnName("logo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(200)
                .HasColumnName("sitio_web");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.ZonaHoraria)
                .HasMaxLength(50)
                .HasDefaultValueSql("'America/Mexico_City'")
                .HasColumnName("zona_horaria");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("citas");

            entity.HasIndex(e => e.CentroId, "centro_id");

            entity.HasIndex(e => e.MedicoId, "medico_id");

            entity.HasIndex(e => e.PacienteId, "paciente_id");

            entity.HasIndex(e => e.TipoCitaId, "tipo_cita_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CentroId).HasColumnName("centro_id");
            entity.Property(e => e.ConfirmacionEnviada)
                .HasDefaultValueSql("'0'")
                .HasColumnName("confirmacion_enviada");
            entity.Property(e => e.CreadaPorStaffId).HasColumnName("creada_por_staff_id");
            entity.Property(e => e.EstaPagada)
                .HasDefaultValueSql("'0'")
                .HasColumnName("esta_pagada");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Agendada'")
                .HasColumnType("enum('Agendada','Confirmada','EnCurso','Completada','Cancelada','NoShow')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCita).HasColumnName("fecha_cita");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaEnvioConfirmacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_envio_confirmacion");
            entity.Property(e => e.FechaEnvioRecordatorio)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_envio_recordatorio");
            entity.Property(e => e.FuenteReserva)
                .HasMaxLength(50)
                .HasColumnName("fuente_reserva");
            entity.Property(e => e.HoraFin)
                .HasColumnType("time")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Motivo)
                .HasMaxLength(300)
                .HasColumnName("motivo");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.NotasInternas)
                .HasColumnType("text")
                .HasColumnName("notas_internas");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.RecordatorioEnviado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("recordatorio_enviado");
            entity.Property(e => e.ReservadaPor)
                .HasMaxLength(100)
                .HasColumnName("reservada_por");
            entity.Property(e => e.TipoCitaId).HasColumnName("tipo_cita_id");

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

        modelBuilder.Entity<Especialidades>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("especialidades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#0066CC'")
                .HasColumnName("color");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionPredeterminadaMinutos)
                .HasDefaultValueSql("'30'")
                .HasColumnName("duracion_predeterminada_minutos");
            entity.Property(e => e.EstaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("esta_activo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<HorariosMedico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("horarios_medicos");

            entity.HasIndex(e => e.MedicoId, "medico_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaDeSemana).HasColumnName("dia_de_semana");
            entity.Property(e => e.EstaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("esta_activo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.HoraFin)
                .HasColumnType("time")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.MedicoId).HasColumnName("medico_id");

            entity.HasOne(d => d.Medico).WithMany(p => p.HorariosMedicos)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("horarios_medicos_ibfk_1");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medicos");

            entity.HasIndex(e => e.CentroId, "centro_id");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Biografia)
                .HasColumnType("text")
                .HasColumnName("biografia");
            entity.Property(e => e.CentroId).HasColumnName("centro_id");
            entity.Property(e => e.CitasDiariasMax)
                .HasDefaultValueSql("'20'")
                .HasColumnName("citas_diarias_max");
            entity.Property(e => e.DuracionCitaPredeterminada)
                .HasDefaultValueSql("'30'")
                .HasColumnName("duracion_cita_predeterminada");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.EstaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("esta_activo");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.ImagenPerfil)
                .HasMaxLength(500)
                .HasColumnName("imagen_perfil");
            entity.Property(e => e.NumeroLicencia)
                .HasMaxLength(50)
                .HasColumnName("numero_licencia");
            entity.Property(e => e.PermitirReservaEnLinea)
                .HasDefaultValueSql("'1'")
                .HasColumnName("permitir_reserva_en_linea");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(100)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.RequiereAprobacion)
                .HasDefaultValueSql("'0'")
                .HasColumnName("requiere_aprobacion");
            entity.Property(e => e.TarifaConsulta)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("tarifa_consulta");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TiempoBuffer)
                .HasDefaultValueSql("'10'")
                .HasColumnName("tiempo_buffer");
            entity.Property(e => e.TrabajaDomingo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("trabaja_domingo");
            entity.Property(e => e.TrabajaJueves)
                .HasDefaultValueSql("'1'")
                .HasColumnName("trabaja_jueves");
            entity.Property(e => e.TrabajaLunes)
                .HasDefaultValueSql("'1'")
                .HasColumnName("trabaja_lunes");
            entity.Property(e => e.TrabajaMartes)
                .HasDefaultValueSql("'1'")
                .HasColumnName("trabaja_martes");
            entity.Property(e => e.TrabajaMiercoles)
                .HasDefaultValueSql("'1'")
                .HasColumnName("trabaja_miercoles");
            entity.Property(e => e.TrabajaSabado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("trabaja_sabado");
            entity.Property(e => e.TrabajaViernes)
                .HasDefaultValueSql("'1'")
                .HasColumnName("trabaja_viernes");

            entity.HasOne(d => d.Centro).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicos_ibfk_1");
        });

        modelBuilder.Entity<MedicoEspecialidades>(entity =>
        {
            entity.HasKey(e => new { e.MedicoId, e.EspecialidadId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("medico_especialidades");

            entity.HasIndex(e => e.EspecialidadId, "especialidad_id");

            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.EspecialidadId).HasColumnName("especialidad_id");
            entity.Property(e => e.EsPrincipal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_principal");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.MedicoEspecialidades)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medico_especialidades_ibfk_2");

            entity.HasOne(d => d.Medico).WithMany(p => p.MedicoEspecialidades)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("medico_especialidades_ibfk_1");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.CentroId, "centro_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alergias)
                .HasColumnType("text")
                .HasColumnName("alergias");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.CentroId).HasColumnName("centro_id");
            entity.Property(e => e.CondicionesCronicas)
                .HasColumnType("text")
                .HasColumnName("condiciones_cronicas");
            entity.Property(e => e.ContactoEmergencia)
                .HasMaxLength(150)
                .HasColumnName("contacto_emergencia");
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.EstaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("esta_activo");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasColumnType("enum('M','F','Otro')")
                .HasColumnName("genero");
            entity.Property(e => e.IdiomaPreferido)
                .HasMaxLength(10)
                .HasDefaultValueSql("'es'")
                .HasColumnName("idioma_preferido");
            entity.Property(e => e.MedicamentosActuales)
                .HasColumnType("text")
                .HasColumnName("medicamentos_actuales");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.NumeroPaciente)
                .HasMaxLength(10)
                .HasColumnName("numero_paciente");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(100)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.RecibirEmail)
                .HasDefaultValueSql("'1'")
                .HasColumnName("recibir_email");
            entity.Property(e => e.RecibirSms)
                .HasDefaultValueSql("'1'")
                .HasColumnName("recibir_sms");
            entity.Property(e => e.RecibirWhatsapp)
                .HasDefaultValueSql("'1'")
                .HasColumnName("recibir_whatsapp");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoAlternativo)
                .HasMaxLength(20)
                .HasColumnName("telefono_alternativo");
            entity.Property(e => e.TelefonoEmergencia)
                .HasMaxLength(20)
                .HasColumnName("telefono_emergencia");
            entity.Property(e => e.TipoSangre)
                .HasMaxLength(5)
                .HasColumnName("tipo_sangre");
            entity.Property(e => e.UltimaVisita)
                .HasColumnType("timestamp")
                .HasColumnName("ultima_visita");

            entity.HasOne(d => d.Centro).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pacientes_ibfk_1");
        });

        modelBuilder.Entity<TiposCita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipos_cita");

            entity.HasIndex(e => e.CentroId, "centro_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CentroId).HasColumnName("centro_id");
            entity.Property(e => e.Color)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#0066CC'")
                .HasColumnName("color");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionMinutos)
                .HasDefaultValueSql("'30'")
                .HasColumnName("duracion_minutos");
            entity.Property(e => e.EstaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("esta_activo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.InstruccionesPreparacion)
                .HasColumnType("text")
                .HasColumnName("instrucciones_preparacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("precio");
            entity.Property(e => e.RequierePreparacion)
                .HasDefaultValueSql("'0'")
                .HasColumnName("requiere_preparacion");

            entity.HasOne(d => d.Centro).WithMany(p => p.TiposCita)
                .HasForeignKey(d => d.CentroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipos_cita_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
