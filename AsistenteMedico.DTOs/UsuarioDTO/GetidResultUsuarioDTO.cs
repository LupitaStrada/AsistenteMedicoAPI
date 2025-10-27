using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMedico.DTOs.UsuarioDTO
{
    public class GetidResultUsuarioDTO
    {
        public int Id { get; set; }

        // Campos de información pública
        public string Correo { get; set; }

        [Display(Name = "Correo")]
        public string Status { get; set; }


        [Display(Name = "Estado")]
        public string Rol { get; set; }


    }
    
}
