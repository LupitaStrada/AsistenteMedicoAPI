using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models.EN;

public partial class MedicoEspecialidad
{
    public int MedicoId { get; set; }

    public int EspecialidadId { get; set; }

    public bool? EsPrincipal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Especialidad Especialidad { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;
}
