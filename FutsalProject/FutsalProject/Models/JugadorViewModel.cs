using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalProject.Models
{
    public class JugadorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public long Dni { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string TelefonoEmergencia { get; set; }

        public string FotoUrl { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Range(0,1, ErrorMessage = "El número ingresado es invalido.")]
        public int IdPieHabil { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string FechaAfiliacion { get; set; }

        public bool Borrado { get; set; }
    }
}
