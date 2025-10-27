using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsistenteMedicoAPI.Models.EN
{
    public class Usuario
    {

        // Mapea a Id INT AUTO_INCREMENT PRIMARY KEY
        public int Id { get; set; }

        // Mapea a Correo VARCHAR(150) NOT NULL UNIQUE
        [Required]
        [Column("Correo")]
        public string Correo { get; set; }

        // Mapea a Password CHAR(64) NOT NULL
        [Required]
        [Column("Password")]
        public string PasswordHash { get; set; }

        // Mapea a Rol VARCHAR(50)
        [Column("Rol")]
        public string Rol { get; set; }

        // Mapea a Status TINYINT NOT NULL DEFAULT 1
        [Column("Status")]



        public byte Status { get; set; }

        // Puedes omitir los campos de fecha si no los usarás activamente en la lógica de EF
    }
}
