using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AulaModeloEF.Data.Entidades
{
    public partial class Aula
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La dirección es requerida.")]
        [StringLength(20, ErrorMessage = "La dirección debe tener como máximo 20 caracteres.")]
        public string? Nombre { get; set; }
        public int? CantidadAlumnos { get; set; }
    }
}
