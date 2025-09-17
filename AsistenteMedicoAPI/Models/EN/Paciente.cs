using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models.EN;

public partial class Paciente
{
    public int Id { get; set; }

    public int CentroId { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? ContactoEmergencia { get; set; }

    public string? TelefonoEmergencia { get; set; }

    public bool? RecibirSms { get; set; }

    public bool? RecibirEmail { get; set; }

    public string? NumeroPaciente { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? UltimaVisita { get; set; }

    public virtual CentroMedico Centro { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
