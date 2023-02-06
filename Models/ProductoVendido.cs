using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Preentrega_Proyecto_Final.Models
{
    internal class ProductoVendido
    {
        private long Id { get; set; }
        private int Stock { get; set; }
        private long IdProducto { get; set; }
        private long IdVenta { get; set; }
    }
}
