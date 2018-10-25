using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalProject.Models
{
    public class TorneoViewModel
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(100, ErrorMessage = "Maximo de tamaño de nombre excedido.")]
        public string Nombre { get; set; }

        [Display(Name = "Identificador Primera Ronda")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int IdPrimeraRonda { get; set; }

        [Display(Name = "Identificador Segunda Ronda")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int? IdSegundaRonda { get; set; }

        [Display(Name = "Identificador Tercera Ronda")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int? IdTerceraRonda { get; set; }

        [Display(Name = "Tiempo de Juego")]
        [Required(ErrorMessage = "Campo requerido")]
        public int? TiempoDeJuego { get; set; }

        [Display(Name = "Fecha de Creacion")]
        [Required(ErrorMessage = "Campo requerido")]
        public string FechaCreacion { get; set; }
        
        [Display(Name = "Borrado Logico")]
        public bool Borrado { get; set; }
    }
}
