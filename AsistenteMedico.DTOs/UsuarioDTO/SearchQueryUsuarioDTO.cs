using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.UsuarioDTO
{
    public class SearchQueryUsuarioDTO
    {

        [Display(Name = "Email")]
        public string? Email_Like { get; set; }

        // Campos para paginación
        public int Skip { get; set; }

        [Display(Name = "Cantidad por Página")]
        public int Take { get; set; }

        // Campo para indicar si se debe devolver el total de registros
        public byte SendRowCount { get; set; }
        // Añade esta línea si no existe.
        public int CountRow { get; set; }
    }
}
