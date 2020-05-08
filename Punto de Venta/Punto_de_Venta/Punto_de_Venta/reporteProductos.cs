using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta
{
    class reporteProductos
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public float precio { get; set; }
        public float costo { get; set; }
        public int minimo { get; set; }
        public int stok { get; set; }
        public string proveedor { get; set; }
        public reporteProductos()
        {

        }
    }
}
