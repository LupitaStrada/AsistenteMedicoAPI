using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

public partial class MedicoEspecialidades
{
    public int MedicoId { get; set; }

    public int EspecialidadId { get; set; }

    public bool? EsPrincipal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Especialidades Especialidad { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;
}
