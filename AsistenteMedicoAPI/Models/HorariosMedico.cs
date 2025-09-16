using System;
using System.Collections.Generic;

namespace AsistenteMedicoAPI.Models;

public partial class HorariosMedico
{
    public int Id { get; set; }

    public int MedicoId { get; set; }

    public int DiaDeSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool? EstaActivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Medico Medico { get; set; } = null!;
}
