using EntradasMvc.Models;
using Microsoft.AspNetCore.Mvc;
using EntradasMvc.ViewModels;

namespace EntradasMvc.Controllers;

public class EntradasController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var viewModel = new CotizacionInputViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calcular(CotizacionInputViewModel viewModelo)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", viewModelo);
        }

        var cotizacion = new Cotizacion
        {
            Cliente = viewModelo.Cliente,
            Cantidad = viewModelo.Cantidad
        };
        var resultadoViewModel = new ResultadoCotizacionViewModel
        {
            Cotizacion = cotizacion,
            Evento = "Concierto Web III",
            FechaEvento = new DateTime(2026, 11, 15),
            Mensaje = "Gracias por realizar su cotizacion."
        };
        return View("Resultado", resultadoViewModel);
    }
}
