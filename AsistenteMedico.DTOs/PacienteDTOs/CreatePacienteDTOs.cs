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
        [Required(ErrorMessage = "El campo Nombre no puede tener mas de 100 caracteres")]
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
        public string? RecibirSms { get; set; }
        [Display(Name = "Recibir Emails")]
        public string? RecibirEmails { get; set; }
    
        [Display(Name = "Numero de paciente")]
        public string? NumeroPaciente { get; set; }

        [Display(Name = "Estado Activo")]
        public string? EstadoActivo { get; set; }

        [Display(Name = "Fecha de creacion")]
        public string? FechaCreacion { get; set; }

        [Display(Name = "Fecha de actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        [Display(Name = "Ultima Visita")]
        public DateTime? UltimaVisita { get; set; }





    }
}
