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
        // ------------------------------------------------------------------
        // CONSTRUCTOR DE INICIALIZACIÓN (Usado típicamente por el GET)
        // ------------------------------------------------------------------
        // Nota: Asumo que esto estaba comentado o lo vas a usar. Lo dejo como ejemplo.

        public EditPacienteDTO(GetIdResultPacienteDTO getIdResultPacientesDTO)
        {
            Id = getIdResultPacientesDTO.Id;
            PrimerNombre = getIdResultPacientesDTO.PrimerNombre;
            Apellido = getIdResultPacientesDTO.Apellido;
            Telefono = getIdResultPacientesDTO.Telefono;
            Email = getIdResultPacientesDTO.Email;
            ContactoEmergencia = getIdResultPacientesDTO.ContactoEmergencia;
            TelefonoEmergencia = getIdResultPacientesDTO.TelefonoEmergencia;
            RecibirEmail = getIdResultPacientesDTO.RecibirEmails;
            RecibirSms = getIdResultPacientesDTO.RecibirSms;
            
        }

        public EditPacienteDTO()
        {
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

        [Display(Name = "Contacto de Emergencia")]
        public string? ContactoEmergencia { get; set; }

        [Display(Name = "Teléfono de Emergencia")]
        public string? TelefonoEmergencia { get; set; }

        [Display(Name = "Recibir Mensajes")]
        public bool RecibirSms { get; set; }

        [Display(Name = "Recibir Email")]
        public bool RecibirEmail { get; set; }
    }
}