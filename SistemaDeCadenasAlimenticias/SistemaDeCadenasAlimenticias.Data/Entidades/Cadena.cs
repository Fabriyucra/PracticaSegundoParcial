using System;
using System.Collections.Generic;

namespace SistemaDeCadenasAlimenticias.Data.Entidades
{
    public partial class Cadena
    {
        public Cadena()
        {
            Sucursals = new HashSet<Sucursal>();
        }

        public int Id { get; set; }
        public string? RazonSocial { get; set; }

        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
