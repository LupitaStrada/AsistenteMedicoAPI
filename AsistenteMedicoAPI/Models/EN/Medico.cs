using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models.EN;

public partial class Medico
{
    public int Id { get; set; }

    public int CentroId { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? NumeroLicencia { get; set; }

    public string? ImagenPerfil { get; set; }

    public string? Biografia { get; set; }

    public decimal? TarifaConsulta { get; set; }

    public int? DuracionCitaPredeterminada { get; set; }

    public int? CitasDiariasMax { get; set; }

    public bool? PermitirReservaEnLinea { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual CentroMedico Centro { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Horariosmedico> Horariosmedicos { get; set; } = new List<Horariosmedico>();

    public virtual ICollection<MedicoEspecialidad> Medicoespecialidades { get; set; } = new List<MedicoEspecialidad>();
}
