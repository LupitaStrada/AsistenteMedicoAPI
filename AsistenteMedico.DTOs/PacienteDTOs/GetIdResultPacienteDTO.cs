using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.PacienteDTOs
{
    public class GetIdResultPacienteDTO
    {
        // Identificador único del paciente
        public int Id { get; set; }

        // Campos de información pública
        public string PrimerNombre { get; set; }

        [Display(Name = "Nombre")]
        public string Apellido { get; set; }

        [Display(Name = "Apellido")]
        public string Telefono { get; set; }

        [Display(Name = "Telefono")]
        public string Email { get; set; }

        [Display(Name = "Correo electronico")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public string Genero { get; set; }

        [Display(Name = "Genero")]
        // Información opcional
        public string ContactoEmergencia { get; set; }

        [Display(Name = "Contacto de emergencia")]
        public string TelefonoEmergencia { get; set; }

     
    }
}
