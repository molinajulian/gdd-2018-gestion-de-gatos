using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public  class Factura
    {
        public int Id { get; set; }
        public string MetodoPago { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public string EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public List<ItemFactura> Items { get; set; }
    }
}
