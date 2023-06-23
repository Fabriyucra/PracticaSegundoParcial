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
        void Editar(Sucursal sucursal);
        void EliminarSucursal(int idSucursal);
        List<Sucursal> GetALLSucursales();
        List<Sucursal> GetSucursalesByIdCadena(int idCadena);
        bool SucursalExistente(int value);
        Sucursal GetSucursalById(int? id);        
    }
    public class SucursalesServicio : ISucursalServicio
    {
        private PW3PracticaSegundoParcialContext _context;
        public SucursalesServicio(PW3PracticaSegundoParcialContext context)
        {
            _context = context;
        }     
        public void Crear(Sucursal sucursal)
        {
            _context.Sucursals.Add(sucursal);
            _context.SaveChanges();
        }

        public void Editar(Sucursal sucursal)
        {
            _context.Sucursals.Update(sucursal);
            _context.SaveChangesAsync();
        }

        public List<Sucursal> GetALLSucursales()
        {
            return _context.Sucursals.ToList();
        }        

        public List<Sucursal> GetSucursalesByIdCadena(int idCadena)
        {
            return _context.Sucursals.Where(s => s.IdCadena == idCadena).ToList();
        }

        public bool SucursalExistente(int id)
        {
            return (_context.Sucursals.Any(s=>s.Id == id));
        }

        public Sucursal GetSucursalById(int? id)
        {
            return _context.Sucursals.FirstOrDefault(s => s.Id == id);
        }     

        public void EliminarSucursal(int idSucursal)
        {
            var sucursal = _context.Sucursals.Find(idSucursal);
            if (sucursal != null)
            {
                _context.Sucursals.Remove(sucursal);
                _context.SaveChanges();
            }
        }      
    }
}
