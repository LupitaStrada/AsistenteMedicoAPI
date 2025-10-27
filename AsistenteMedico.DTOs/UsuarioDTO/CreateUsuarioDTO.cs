using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.UsuarioDTO
{
    public class CreateUsuarioDTO
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo correo electronico es obligatorio")]
        public string Correo { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo Stado es obligatorio")]
        public byte Status { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo rol es obligatorio")]
        public string Rol { get; set; } = string.Empty;

       
    }
}
