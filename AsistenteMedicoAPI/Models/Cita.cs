using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

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

    public string? NotasInternas { get; set; }

    public decimal? Precio { get; set; }

    public bool? EstaPagada { get; set; }

    public string? MetodoPago { get; set; }

    public bool? RecordatorioEnviado { get; set; }

    public DateTime? FechaEnvioRecordatorio { get; set; }

    public bool? ConfirmacionEnviada { get; set; }

    public DateTime? FechaEnvioConfirmacion { get; set; }

    public string? ReservadaPor { get; set; }

    public string? FuenteReserva { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int? CreadaPorStaffId { get; set; }

    public virtual CentrosMedico Centro { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual TiposCita? TipoCita { get; set; }
}
