using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.PacienteDTOs
{
    public class EditPacienteDTO
    {
        // Constructor que inicializa el DTO desde una clase de resultado de obtención de datos
        public EditPacienteDTO(GetIdResultPacienteDTO getIdResultPacientesDTO)
        {
            Id = getIdResultPacientesDTO.Id;
            PrimerNombre = getIdResultPacientesDTO.PrimerNombre;
            Apellido = getIdResultPacientesDTO.Apellido;
            Telefono = getIdResultPacientesDTO.Telefono;
            Email = getIdResultPacientesDTO.Email;
            FechaNacimiento = getIdResultPacientesDTO.FechaNacimiento;
            Genero = getIdResultPacientesDTO.Genero;
            ContactoEmergencia = getIdResultPacientesDTO.ContactoEmergencia;
            TelefonoEmergencia = getIdResultPacientesDTO.TelefonoEmergencia;
        }

        // Constructor vacío para inicializar sin valores
        public EditPacienteDTO()
        {
            Id = 0;
            PrimerNombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Genero = string.Empty;
        }

        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "El campo Primer Nombre es obligatorio")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido")]
        public string? Email { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Género")]
        public string? Genero { get; set; }

        [Display(Name = "Contacto de Emergencia")]
        public string? ContactoEmergencia { get; set; }

        [Display(Name = "Teléfono de Emergencia")]
        public string? TelefonoEmergencia { get; set; }
    }
}
