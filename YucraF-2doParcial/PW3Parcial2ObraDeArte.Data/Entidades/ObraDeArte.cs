using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PW3Parcial2ObraDeArte.Data.Entidades
{
    public partial class ObraDeArte
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La Nombre es requerida.")]
        [StringLength(20, ErrorMessage = "El Nombre debe tener como máximo 20 caracteres.")]
        public string? Nombre { get; set; }
        public int? AnioCreacion { get; set; }
    }
}
