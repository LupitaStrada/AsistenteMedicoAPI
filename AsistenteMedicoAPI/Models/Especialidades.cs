using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

public partial class Especialidade
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Color { get; set; }

    public int? DuracionPredeterminadaMinutos { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<MedicoEspecialidades> MedicoEspecialidades { get; set; } = new List<MedicoEspecialidades>();
}
