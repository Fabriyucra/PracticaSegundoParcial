using System;
using System.Collections.Generic;

namespace SistemaDeCadenasAlimenticias.Data.Entidades
{
    public partial class Sucursal
    {
        public int Id { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public int? IdCadena { get; set; }

        public virtual Cadena? IdCadenaNavigation { get; set; }
    }
}
