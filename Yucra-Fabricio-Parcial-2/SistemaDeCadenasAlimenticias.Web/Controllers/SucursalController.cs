using Microsoft.AspNetCore.Mvc;
using SistemaDeCadenasAlimenticias.Data;
using SistemaDeCadenasAlimenticias.Data.Entidades;
using SistemaDeCadenasAlimenticias.Servicio;
using System.Data.Entity.Infrastructure;

namespace SistemaDeCadenasAlimenticias.Web.Controllers
{
    public class SucursalController : Controller
    {
        private ISucursalServicio _sucursalesServicios;
        private ICadenasServicios _cadenasServicios;
        public SucursalController(ISucursalServicio isucursalServicio, ICadenasServicios cadenasServicios)
        {
            _sucursalesServicios = isucursalServicio;
            _cadenasServicios = cadenasServicios;
        }

        public IActionResult Index(int? idCadena)
        {
            // Obtener la lista de cadenas ordenadas por nombre
            List<Cadena> cadenas = _cadenasServicios.GetAllCadenas(); //llama al get del contexto

            // Agregar la lista de cadenas a ViewBag para que esté disponible en la vista
            ViewBag.Cadenas = cadenas;          

            // Obtener la lista de sucursales
            List<Sucursal> sucursales = _sucursalesServicios.GetALLSucursales();//llama al get del contexto

            if (idCadena.HasValue) //vemos si el valor q devuelve la View es null, si no lo es hacemos la parte del filtro (.HasValue solo para valores nulleables)
            {
                // Filtrar por la cadena seleccionada si se proporciona un idCadena válido
                sucursales = _sucursalesServicios.GetSucursalesByIdCadena(idCadena.Value);
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

                _sucursalesServicios.Crear(sucursal);// comitea los cambios y se resuelven todos los cambios en la base de datos 
                return RedirectToAction("Index");
            }
            ViewBag.Cadenas = _cadenasServicios.GetAllCadenas();
            return View(sucursal);
        }

        // GET: Aulas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || !_sucursalesServicios.SucursalExistente(id.Value)) 
            {
                return NotFound();
            }

            var sucursal = _sucursalesServicios.GetSucursalById(id.Value);//donde usa el contexto para pasorlo por la view
                                                                          //
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }
        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_sucursalesServicios.SucursalExistente(id))
            {
                return Problem("Entity set 'Sucursal' is null.");
            }

            _sucursalesServicios.EliminarSucursal(id);
            return RedirectToAction(nameof(Index));
        }


        // GET: ObraDeArtes/Edit/5
        public IActionResult Edit(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = _sucursalesServicios.GetSucursalById(id.Value);
            if (sucursal == null)
            {
                return NotFound();
            }
            ViewBag.Cadenas = _cadenasServicios.GetAllCadenas();
            return View(sucursal);
        }

        // POST: ObraDeArtes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sucursal sucursal)
        {
            if (id != sucursal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _sucursalesServicios.Editar(sucursal);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cadenas = _cadenasServicios.GetAllCadenas();
            return View(sucursal);
        }

    }
}
