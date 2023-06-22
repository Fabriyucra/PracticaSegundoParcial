using SistemaDeCadenasAlimenticias.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadenasAlimenticias.Servicio
{
    public interface ICadenasServicios
    {
        List<Cadena> GetAllCadenas();
    }
    public class CadenasServicios : ICadenasServicios
    {
        private PW3PracticaSegundoParcialContext _context;
        public CadenasServicios(PW3PracticaSegundoParcialContext context)
        {
            _context = context;
        }

        public List<Cadena> GetAllCadenas()
        {
            return _context.Cadenas.OrderBy(c => c.RazonSocial).ToList();
        }
    }
}
