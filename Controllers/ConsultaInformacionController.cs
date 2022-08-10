using Dominio.IServicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Transporte;

namespace Pedidos.Controllers {
    public class ConsultaInformacionController : Controller {
        private readonly IConsultaPedidoService _IConsultaPedidoService;

        public ConsultaInformacionController(IConsultaPedidoService iConsultaPedidoService) {
            _IConsultaPedidoService = iConsultaPedidoService;
        }

        [HttpPost]
        public async Task<ActionResult> ConsultaPedidosGeneral(ModeloConsultaDTO modelo) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var lista = await _IConsultaPedidoService.ConsultaPedidosGeneral(modelo);

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            return PartialView(lista);
        }
    }
}
