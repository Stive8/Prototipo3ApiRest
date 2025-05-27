using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class Medidor
    {

        public long id { get; set; }
        public string marca { get; set; }
        public string serial { get; set; }
        public double diametro { get; set; }
        public DateTime fechaInstalacion { get; set; }
        public string estado { get; set; }


        public Residencial predio { get; set; }

        // Propiedad auxiliar que se usará en el DataGridView
        public long? idPredio
        {
            get { return predio != null ? predio.id : (long?)null; }
        }

    }
}
