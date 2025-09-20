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
            //FechaNacimiento = getIdResultPacientesDTO.FechaNacimiento;
            //Genero = getIdResultPacientesDTO.Genero;
            ContactoEmergencia = getIdResultPacientesDTO.ContactoEmergencia;
            TelefonoEmergencia = getIdResultPacientesDTO.TelefonoEmergencia;
            
            
     
          



        }

        // Constructor vacío para inicializar sin valores
        public class EditarPacienteDTO
        {
            public int Id { get; set; }
            public string PrimerNombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string? Email { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public string? ContactoEmergencia { get; set; }
            public string? TelefonoEmergencia { get; set; }
            public bool? RecibirSms { get; set; }
            public bool? RecibirEmail { get; set; }
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
        public bool? RecibirSms { get; set; }

        [Display(Name = "Recibir Email")]
        public bool? RecibirEmail { get; set; }



    }
}
