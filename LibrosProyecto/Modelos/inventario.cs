using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class inventario
    {
        public int id { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public string FechaAdquision { get; set; }
        public string TipoAdquision { get; set; }
        public string Observaciones { get; set; }
        public int AREAS_id { get; set; }

        public inventario(int id, string nombreCorto, string descripcion, string serie, string color, string fechaAdquision, string tipoAdquision, string observaciones, int aREAS_id)
        {
            this.id = id;
            NombreCorto = nombreCorto;
            Descripcion = descripcion;
            Serie = serie;
            Color = color;
            FechaAdquision = fechaAdquision;
            TipoAdquision = tipoAdquision;
            Observaciones = observaciones;
            AREAS_id = aREAS_id;
        }

        public inventario() { }
    }
}
