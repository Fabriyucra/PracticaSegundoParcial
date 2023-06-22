using SistemaDeCadenasAlimenticias.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadenasAlimenticias.Servicio
{
    public interface ISucursalServicio {
        void Crear(Sucursal sucursal);
        List<Sucursal> GetALLSucursales();
        List<Sucursal> GetSucursalesByIdCadena(int idCadena);

    }
    public class SucursalServicio : ISucursalServicio
    {
        private PW3PracticaSegundoParcialContext _context;
        public SucursalServicio(PW3PracticaSegundoParcialContext context)
        {
            _context = context;
        }     
        public void Crear(Sucursal sucursal)
        {
            _context.Sucursals.Add(sucursal);
            _context.SaveChanges();
        }

        public List<Sucursal> GetALLSucursales()
        {
            return _context.Sucursals.ToList();
        }

        public List<Sucursal> GetSucursalesByIdCadena(int idCadena)
        {
            return _context.Sucursals.Where(s => s.IdCadena == idCadena).ToList();
        }
    }
}
