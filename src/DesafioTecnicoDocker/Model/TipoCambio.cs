using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DesafioTecnicoDocker.Model.Enum;

namespace DesafioTecnicoDocker.Model
{
    public class TipoCambio
    {
        public moneda Origen { get; set; }
        public moneda Destino { get; set; }
        public decimal Valor { get; set; }
    }
}
