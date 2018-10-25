using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalProject.Models
{
    public class JugadorViewModel
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Doc")]
        [Required(ErrorMessage = "Campo requerido.")]
        public long Dni { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Nombres { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string FechaNacimiento { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Telefono { get; set; }

        [Display(Name = "Teléfono de emergencia")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string TelefonoEmergencia { get; set; }

        [Display(Name = "Direccion imagen")]
        public string FotoUrl { get; set; }

        [Display(Name = "Pie hábil")]
        [Required(ErrorMessage = "Campo requerido.")]
        [Range(1,3, ErrorMessage = "El número ingresado es invalido.")]
        public int IdPieHabil { get; set; }

        [Display(Name = "Fecha de afiliación")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string FechaAfiliacion { get; set; }

        [Display(Name = "Baja lógica")]
        public bool Borrado { get; set; }
    }
}
