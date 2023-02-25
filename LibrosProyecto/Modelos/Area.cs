using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Area
    {
        public int id { get; set; }
        public String Nombre { get; set; }
        public String Ubicacion { get; set; }

        public Area(int Id, string nombre, string ubicacion)
        {
            id = Id;
            Nombre = nombre;
            Ubicacion = ubicacion;
        }
        public Area() { }
    }
}
