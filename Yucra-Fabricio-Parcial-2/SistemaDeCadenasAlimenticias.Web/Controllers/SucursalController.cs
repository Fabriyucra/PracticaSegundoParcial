using Microsoft.AspNetCore.Mvc;
using SistemaDeCadenasAlimenticias.Data;
using SistemaDeCadenasAlimenticias.Data.Entidades;
using SistemaDeCadenasAlimenticias.Servicio;

namespace SistemaDeCadenasAlimenticias.Web.Controllers
{
    public class SucursalController : Controller
    {
        private ISucursalServicio _sucursalServicio;
        private ICadenasServicios _cadenasServicios;
        public SucursalController(ISucursalServicio isucursalServicio, ICadenasServicios cadenasServicios)
        {
            _sucursalServicio = isucursalServicio;
            _cadenasServicios = cadenasServicios;
        }

        public IActionResult Index(int? idCadena)
        {
            // Obtener la lista de cadenas ordenadas por nombre
            List<Cadena> cadenas = _cadenasServicios.GetAllCadenas(); //llama al get del contexto

            // Agregar la lista de cadenas a ViewBag para que esté disponible en la vista
            ViewBag.Cadenas = cadenas;          

            // Obtener la lista de sucursales
            List<Sucursal> sucursales = _sucursalServicio.GetALLSucursales();//llama al get del contexto

            if (idCadena.HasValue) //vemos si el valor q devuelve la View es null, si no lo es hacemos la parte del filtro (.HasValue solo para valores nulleables)
            {
                // Filtrar por la cadena seleccionada si se proporciona un idCadena válido
                sucursales = _sucursalServicio.GetSucursalesByIdCadena(idCadena.Value);
            }

            return View(sucursales);// sucursales sera devuelto o todas o la q tiene un filtro depende si es Null o no 
        }

        public IActionResult Crear()
        {
            ViewBag.Cadenas = _cadenasServicios.GetAllCadenas(); // pasamos todos los datos de cadena de forma ordena por nombre
            return View(new Sucursal());
        }
        [HttpPost]
        public IActionResult Crear(Sucursal sucursal)
        {
            if (ModelState.IsValid)// valida si lo que devolvio la View cumple con las necesidades del modelo que se quiere usar
            {

                _sucursalServicio.Crear(sucursal);// comitea los cambios y se resuelven todos los cambios en la base de datos 
                return RedirectToAction("Index");
            }
            ViewBag.Cadenas = _cadenasServicios.GetAllCadenas();
            return View(sucursal);
        }
    }
}
