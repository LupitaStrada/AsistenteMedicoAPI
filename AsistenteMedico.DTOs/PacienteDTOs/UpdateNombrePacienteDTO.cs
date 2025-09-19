using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.PacienteDTOs
{
    public class UpdateNombrePacienteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PrimerNombre { get; set; }
    }
}
