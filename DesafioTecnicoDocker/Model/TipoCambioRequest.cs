using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DesafioTecnicoDocker.Model.Enum;

namespace DesafioTecnicoDocker.Model
{
    public class TipoCambioRequest
    {
        public decimal monto { get; set; }
        public moneda monedaOrigen { get; set; }
        public moneda monedaDestino { get; set; }
    }
}
