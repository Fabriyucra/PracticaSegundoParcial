using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadenasAlimenticias.Data.Entidades
{
    public partial class Sucursal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Direccion no puede tener más de 50 caracteres.")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El campo Ciudad es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Ciudad no puede tener más de 50 caracteres.")]
        public string? Ciudad { get; set; }
        [Required(ErrorMessage = "El campo IdCadena es obligatorio.")]
        public int? IdCadena { get; set; }

        public virtual Cadena? IdCadenaNavigation { get; set; }
    }
}
