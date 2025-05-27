using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class RequestMedidor
    {
        public string marca { get; set; }
        public string serial { get; set; }
        public double diametro { get; set; }
        public DateTime fechaInstalacion { get; set; }
        public string estado { get; set; }
        public long idPredio { get; set; } // solo el ID del predio relacionado

    }
}
