using SistemaDeCadenasAlimenticias.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadenasAlimenticias.Servicio
{
    public interface ISucursalServicio {
        List<Sucursal> SucursalGetAll();
        List<Cadena> CadenaGetAll();
        List<Sucursal> SucursalesByIdCadena(int idCadena);
        void CrearSucursal(Sucursal sucursal);

    }
    public class SucursalServicio : ISucursalServicio
    {
        private PW3PracticaSegundoParcialContext _context;
        public SucursalServicio(PW3PracticaSegundoParcialContext context)
        {
            _context = context;
        }

        public List<Cadena> CadenaGetAll()
        {
            return _context.Cadenas.OrderBy(c => c.Id).ToList();
        }       

        public List<Sucursal> SucursalesByIdCadena(int idCadena)
        {
            return _context.Sucursals.Where(s=> s.IdCadena == idCadena).ToList();
        }

        public List<Sucursal> SucursalGetAll()
        {
            return _context.Sucursals.ToList();
        }
        public void CrearSucursal(Sucursal sucursal)
        {
            _context.Sucursals.Add(sucursal);
            _context.SaveChanges();
        }
    }
}
