using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.PacienteDTOs
{
    public class SearchResultPacienteDTO
    {
        // Total de registros encontrados (útil para la paginación)
        public int CountRow { get; set; }

        // La lista de pacientes que coinciden con la búsqueda
        public List<PacienteDTO> Data { get; set; }

        public class PacienteDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string PrimerNombre { get; set; }

            [Display(Name = "Apellido")]
            public string Apellido { get; set; }

            [Display(Name = "Teléfono")]
            public string Telefono { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Fecha de Nacimiento")]
            public DateTime? FechaNacimiento { get; set; }
        }
    }
}
