using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.PacienteDTOs
{
    public class CreatePacienteDTOs
    {
        [Display(Name = "Centro Medico")]
        [Required(ErrorMessage = "El campo centro medico es obligatorio")]
        public int CentroId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string PrimerNombre { get; set; } = string.Empty;

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }= string.Empty;

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Telefono { get; set; }= string.Empty;

        [Display(Name = "Correo Electronico")]
        public string? Email { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Contacto de emergencia")]
        public string? ContactoEmergencia { get; set;}

        [Display(Name = "Telefono de emergencia")]
        public string? TelefonoEmergencia { get; set; }

        [Display(Name = "Recibir mensajes")]
        public bool RecibirSms { get; set; }
        [Display(Name = "Recibir Emails")]
        public bool RecibirEmails { get; set; }
    
        [Display(Name = "Numero de paciente")]
        [Required(ErrorMessage = "El campo Numero de paciente es obligatorio")]
        [MaxLength(10, ErrorMessage = "El campo Número de Paciente no puede tener más de 10 caracteres.")]
        public string? NumeroPaciente { get; set; }
        [Display(Name = "Género")]
   
        public string? Genero { get; set; }

    }
}
