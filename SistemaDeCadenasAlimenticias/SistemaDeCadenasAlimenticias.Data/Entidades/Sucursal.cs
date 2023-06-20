using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadenasAlimenticias.Data.Entidades
{
    public partial class Sucursal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La dirección es requerida.")]
        [StringLength(50, ErrorMessage = "La dirección debe tener como máximo 50 caracteres.")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "La ciudad es requerida.")]
        [StringLength(50, ErrorMessage = "La ciudad debe tener como máximo 50 caracteres.")]
        public string? Ciudad { get; set; }
        public int? IdCadena { get; set; }

        public virtual Cadena? IdCadenaNavigation { get; set; }
    }
}
