using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTecnicoDocker.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DesafioTecnicoDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoCambioController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;

        public TipoCambioController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;

            var data = memoryCache.Get("OPERACION");
            if (data == null) memoryCache.Set("OPERACION", new List<TipoCambioResponse>());

            var dataLTC = memoryCache.Get("LISTATIPOCAMBIO");
            if (dataLTC == null) memoryCache.Set("LISTATIPOCAMBIO", ListaTipoCambio());
        }

        [HttpPost("TipoCambio")]
        public IActionResult TipoCambio(TipoCambioRequest request)
        {
            TipoCambioResponse response = new TipoCambioResponse();
            response.monto = request.monto;

            decimal tipoCambio = this.ListaTipoCambio().FirstOrDefault(x => x.Origen == request.monedaOrigen && x.Destino == request.monedaDestino).Valor;

            response.montoConTipoCambio = request.monto * tipoCambio;
            response.monedaOrigen = request.monedaOrigen;
            response.monedaDestino = request.monedaDestino;
            response.tipoCambio = tipoCambio;

            var data = (List<TipoCambioResponse>)memoryCache.Get("OPERACION");
            data.Add(response);
            memoryCache.Set("OPERACION", data);
            return Ok(response);
        }

        [HttpPost("ActualizaTipoCambio")]
        public IActionResult ActualizaTipoCambio(MontoTipoCambioRequest request)
        {
            bool response = false;
            var data = (List<TipoCambio>)memoryCache.Get("LISTATIPOCAMBIO");

            TipoCambio tipoCambio = data.FirstOrDefault(x => x.Origen == request.monedaOrigen && x.Destino == request.monedaDestino);

            tipoCambio.Valor = request.montoTipoCambio;
            
            memoryCache.Set("LISTATIPOCAMBIO", data);

            response = true;

            return Ok(response);
        }

        [HttpGet("ObtenerOperaciones")]
        public IActionResult ObtenerOperaciones()
        {
            var data = (List<TipoCambioResponse>)memoryCache.Get("OPERACION");
            return Ok(data);
        }

        [HttpGet("ObtenerListaTipoCambio")]
        public IActionResult ObtenerListaTipoCambio()
        {
            var data = (List<TipoCambio>)memoryCache.Get("LISTATIPOCAMBIO");
            return Ok(data);
        }

        private List<TipoCambio> ListaTipoCambio()
        {

            var lista = new List<TipoCambio>();
            lista.Add(new TipoCambio { Origen = Model.Enum.moneda.soles, Destino = Model.Enum.moneda.dolares, Valor = 0.25M });
            lista.Add(new TipoCambio { Origen = Model.Enum.moneda.soles, Destino = Model.Enum.moneda.euros, Valor = 0.25M });
            lista.Add(new TipoCambio { Origen = Model.Enum.moneda.euros, Destino = Model.Enum.moneda.soles, Valor = 4.01M });
            lista.Add(new TipoCambio { Origen = Model.Enum.moneda.euros, Destino = Model.Enum.moneda.dolares, Valor = 1.02M });
            lista.Add(new TipoCambio { Origen = Model.Enum.moneda.dolares, Destino = Model.Enum.moneda.soles, Valor = 3.93M });
            lista.Add(new TipoCambio { Origen = Model.Enum.moneda.dolares, Destino = Model.Enum.moneda.euros, Valor = 0.98M });
            return lista;
        }
    }
}
