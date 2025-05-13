using System;

namespace Cliente
{
    internal class Request
    {
        public long codigo { get; set; }
        public string representanteLegal { get; set; }
        public string direccion { get; set; }
        //public string EstadoCuenta { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int estrato { get; set; }
        public double consumo { get; set; }
        public double valorFactura { get; set; }
        //public double Subsidio { get; set; }
        //public string TipoComercio { get; set; }

        //public string TCodigoLicencia { get; set; }
    }
}