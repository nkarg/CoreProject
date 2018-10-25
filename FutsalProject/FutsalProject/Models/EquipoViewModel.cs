using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalProject.Models
{
    public class EquipoViewModel
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Nombre Largo")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string NombreLargo { get; set; }

        [Display(Name = "Nombre Corto")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(25, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string NombreCorto { get; set; }

        public string EscudoUrl { get; set; }

        [Display(Name = "Fecha de afiliación")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string FechaAfiliacion { get; set; }

        [Display(Name = "Baja lógica")]
        public bool Borrado { get; set; }
    }
}
