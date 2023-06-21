using Microsoft.AspNetCore.Mvc;
using SistemaDeCadenasAlimenticias.Data;
using SistemaDeCadenasAlimenticias.Data.Entidades;
using SistemaDeCadenasAlimenticias.Servicio;

namespace SistemaDeCadenasAlimenticias.Web.Controllers
{
    public class SucursalController : Controller
    {
        private ISucursalServicio _isucursalServicio;
        public SucursalController(ISucursalServicio isucursalServicio)
        {
            _isucursalServicio = isucursalServicio;
        }

        public IActionResult Index(int? idCadena)
        {
            // Obtener la lista de cadenas ordenadas por nombre
            List<Cadena> cadenas = _isucursalServicio.CadenaGetAll(); //llama al get del contexto

            // Agregar la lista de cadenas a ViewBag para que esté disponible en la vista
            ViewBag.Cadenas = cadenas;

            // Obtener la lista de sucursales filtradas según la cadena seleccionada
            List<Sucursal> sucursales = _isucursalServicio.SucursalGetAll();//llama al get del contexto

            if (idCadena.HasValue)
            {
                // Filtrar por la cadena seleccionada si se proporciona un idCadena válido
                sucursales = _isucursalServicio.SucursalesByIdCadena(idCadena.Value);
            }

            return View(sucursales);
        }

        public IActionResult Crear()
        {
            ViewBag.Cadenas = _isucursalServicio.CadenaGetAll(); // pasamos todos los datos de cadena de forma ordena por nombre
            return View(new Sucursal());
        }
        [HttpPost]
        public IActionResult Crear(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {// valida si existe model

                _isucursalServicio.CrearSucursal(sucursal);// comitea los cambios y se resuelven todos los cambios en la base de datos 
                return RedirectToAction("Index");
            }
            ViewBag.Cadenas = _isucursalServicio.CadenaGetAll();
            return View(sucursal);
        }
    }
}
