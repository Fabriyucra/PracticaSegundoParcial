using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadenasAlimenticias.Data.Entidades
{
    public partial class Cadena
    {
        public Cadena()
        {
            Sucursals = new HashSet<Sucursal>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo RazonSocial es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo RazonSocial no puede tener más de 50 caracteres.")]
        public string? RazonSocial { get; set; }

        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
