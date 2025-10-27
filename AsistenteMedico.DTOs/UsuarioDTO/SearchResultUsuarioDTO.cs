using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.UsuarioDTO
{
    public class SearchResultUsuarioDTO
    {
        public int CountRow { get; set; }

        // La lista de pacientes que coinciden con la búsqueda
        public List<UsuarioDTO> Data { get; set; }

        public class UsuarioDTO
        {
            public int Id { get; set; }

            [Display(Name = "Correo")]
            public string Correo { get; set; }

            [Display(Name = "Estado")]
            public String Status { get; set; }

            [Display(Name = "Rol")]
            public string Rol { get; set; }

        
        }
    }
}
