using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Usuario
    {
        [Key]
        public int Identificador { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        public string Pass { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}