using SistemaDeCadenasAlimenticias.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SistemaDeCadenasAlimenticias.Web.Controllers
{
    public class SucursalController : Controller
    {
        private PW3PracticaSegundoParcialContext _context; //contexto para trabajar con lo que pued devolver la base 

        public SucursalController(PW3PracticaSegundoParcialContext context) //constructor q ejecuta el contexto
        {
            _context = context;
        }

        public IActionResult Index(int? idCadena)
        {
            // Obtener la lista de cadenas ordenadas por nombre
            List<Cadena> cadenas = _context.Cadenas.OrderBy(c => c.RazonSocial).ToList(); //llama al get del contexto

            // Agregar la lista de cadenas a ViewBag para que esté disponible en la vista
            ViewBag.Cadenas = cadenas;

            // Obtener la lista de sucursales filtradas según la cadena seleccionada
            List<Sucursal> sucursales = _context.Sucursals.ToList();//llama al get del contexto

            if (idCadena.HasValue)
            {
                // Filtrar por la cadena seleccionada si se proporciona un idCadena válido
                sucursales = sucursales.Where(s => s.IdCadena == idCadena).ToList();
            }

            return View(sucursales);
        }
        public IActionResult Crear() {
            ViewBag.Cadenas = _context.Cadenas.OrderBy(c => c.RazonSocial).ToList(); // pasamos todos los datos de cadena de forma ordena por nombre
        return View( new Sucursal());
        }

        [HttpPost]
        public IActionResult Crear(Sucursal sucursal)
        {
            if (ModelState.IsValid) {// valida si existe model

                _context.Sucursals.Add(sucursal);
                _context.SaveChanges();// comitea los cambios y se resuelven todos los cambios en la base de datos 
                return RedirectToAction("Index");
            }
            ViewBag.Cadenas = _context.Cadenas.OrderBy(c => c.RazonSocial).ToList();
            return View(sucursal);
        }
    }
}
