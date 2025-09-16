using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

public partial class CentrosMedico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? SitioWeb { get; set; }

    public string? Logo { get; set; }

    public TimeOnly? HorarioInicio { get; set; }

    public TimeOnly? HorarioFin { get; set; }

    public string? ZonaHoraria { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<TiposCita> TiposCita { get; set; } = new List<TiposCita>();
}
