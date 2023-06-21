using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PW3Parcial2ObraDeArte.Data.Entidades;

namespace PW3Parcial2ObraDeArte.Servicio
{
    public interface IObraDeArteServicio {
        List<ObraDeArte> ObtenerSigloVeinte();
        List<ObraDeArte> ObtenerTodos();
    }
    public class ObraDeArteServicio : IObraDeArteServicio
    {
        private ModeloEFContext _contexto;
        public ObraDeArteServicio(ModeloEFContext contexto) { 
            _contexto = contexto;
        }
          List<ObraDeArte> IObraDeArteServicio.ObtenerSigloVeinte()
        {
            return _contexto.ObraDeArtes
                .Where(o => o.AnioCreacion >= 1800 && o.AnioCreacion <= 1899)
                .OrderBy(c => c.Nombre)
                .ToList();
        }

        List<ObraDeArte> IObraDeArteServicio.ObtenerTodos()
        {
            return _contexto.ObraDeArtes               
               .OrderBy(c => c.Nombre)
               .ToList();
        }
    }
}
