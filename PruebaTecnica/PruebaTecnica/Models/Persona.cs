using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Persona
    {
        [Key]
        public int Identificador { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(50)]
        public string NumeroIdentificacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoIdentificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NumeroIdentificacionConcatenado { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NombresApellidosConcatenados { get; set; }
    }
}