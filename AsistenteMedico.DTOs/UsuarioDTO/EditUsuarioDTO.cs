using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.UsuarioDTO
{
    public class EditUsuarioDTO
    {
        public EditUsuarioDTO()
        {
        }

        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Correo no tiene un formato válido")]
        public string Correo { get; set; } // Mapea al campo 'Correo' de la DB


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        // En tu DB, 'Status' es TINYINT, así que usamos byte
        public byte Status { get; set; } // Mapea al campo 'Status' de la DB

        [Display(Name = "Nueva Contraseña")]
        // La contraseña suele ser opcional en la edición de perfil. No es [Required].
        public string? NewPassword { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo Rol es obligatorio")]
        // Aquí puedes usar un enum si tienes roles predefinidos (Admin, Doctor, Paciente)
        public string Rol { get; set; } // Mapea al campo 'Rol' de la DB
    }
}
