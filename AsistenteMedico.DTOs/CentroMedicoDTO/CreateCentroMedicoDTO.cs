using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.CentroMedicoDTO
{
    public class CreateCentroMedicoDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        public string Direccion { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo Direccion no puede tener mas de 255 caracteres")]
        [MaxLength(255, ErrorMessage = "El campo telefono no puede tener mas de 50 caracteres")]
        public string? Telefono { get; set; }
    }
}
