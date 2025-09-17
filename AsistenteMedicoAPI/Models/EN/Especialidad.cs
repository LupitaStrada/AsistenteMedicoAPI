using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models.EN;

public partial class Especialidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Color { get; set; }

    public int? DuracionPredeterminadaMinutos { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<MedicoEspecialidad> Medicoespecialidades { get; set; } = new List<MedicoEspecialidad>();
}
