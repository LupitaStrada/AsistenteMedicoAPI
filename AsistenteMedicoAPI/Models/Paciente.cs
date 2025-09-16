using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public int CentroId { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Email { get; set; }

    public string Telefono { get; set; } = null!;

    public string? TelefonoAlternativo { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? TipoSangre { get; set; }

    public string? Direccion { get; set; }

    public string? ContactoEmergencia { get; set; }

    public string? TelefonoEmergencia { get; set; }

    public string? IdiomaPreferido { get; set; }

    public bool? RecibirSms { get; set; }

    public bool? RecibirEmail { get; set; }

    public bool? RecibirWhatsapp { get; set; }

    public string? Alergias { get; set; }

    public string? CondicionesCronicas { get; set; }

    public string? MedicamentosActuales { get; set; }

    public string? Notas { get; set; }

    public string? NumeroPaciente { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? UltimaVisita { get; set; }

    public virtual CentrosMedico Centro { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
