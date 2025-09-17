using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models.EN;

public partial class Cita
{
    public int Id { get; set; }

    public int CentroId { get; set; }

    public int PacienteId { get; set; }

    public int MedicoId { get; set; }

    public int? TipoCitaId { get; set; }

    public DateOnly FechaCita { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string? Estado { get; set; }

    public string? Motivo { get; set; }

    public string? Notas { get; set; }

    public string? NotasMedicas { get; set; }

    public decimal? Precio { get; set; }

    public bool? EstaPagada { get; set; }

    public string? MetodoPago { get; set; }

    public string? CreadaPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual CentroMedico Centro { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual TiposCita? TipoCita { get; set; }
}
