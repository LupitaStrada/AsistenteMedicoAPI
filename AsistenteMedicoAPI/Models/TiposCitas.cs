using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

public partial class TiposCitas
{
    public int Id { get; set; }

    public int CentroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? DuracionMinutos { get; set; }

    public decimal? Precio { get; set; }

    public string? Color { get; set; }

    public bool? RequierePreparacion { get; set; }

    public string? InstruccionesPreparacion { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual CentrosMedico Centro { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
