using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models.EN;

public partial class TiposCita
{
    public int Id { get; set; }

    public int CentroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? DuracionMinutos { get; set; }

    public decimal? Precio { get; set; }

    public string? Color { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual CentroMedico Centro { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
