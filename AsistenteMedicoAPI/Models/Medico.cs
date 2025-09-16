using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

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

    public int? TiempoBuffer { get; set; }

    public int? CitasDiariasMax { get; set; }

    public bool? PermitirReservaEnLinea { get; set; }

    public bool? RequiereAprobacion { get; set; }

    public bool? TrabajaLunes { get; set; }

    public bool? TrabajaMartes { get; set; }

    public bool? TrabajaMiercoles { get; set; }

    public bool? TrabajaJueves { get; set; }

    public bool? TrabajaViernes { get; set; }

    public bool? TrabajaSabado { get; set; }

    public bool? TrabajaDomingo { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual CentrosMedico Centro { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<HorariosMedico> HorariosMedicos { get; set; } = new List<HorariosMedico>();

    public virtual ICollection<MedicoEspecialidade> MedicoEspecialidades { get; set; } = new List<MedicoEspecialidade>();
}
