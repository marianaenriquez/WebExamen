using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ventasWeb.Models;
using ventasWeb.Service;

namespace ventasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult VentasP()
        {
            return View();
        }
        public IActionResult VentasG()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult ConsultaVentaP( int id) //metodo publico que regresa un arreglo de texto con nombre get
        {
            var Consulta = new ClaseAccesoDatos(); //regresa una nueva cadena de texto 
            var Lista = Consulta.ConsultaVentas(id);
            return  Json(Lista);
        }

        [HttpPost]
        public ActionResult ConsultaVenta() //metodo publico que regresa un arreglo de texto con nombre get
        {
            var Consulta = new ClaseAccesoDatos(); //regresa una nueva cadena de texto 
            var Lista = Consulta.ConsultaTabla();
            return Json(Lista);
        }


        [HttpPost]
        public ActionResult ConsultaPro(int id ) //metodo publico que regresa un arreglo de texto con nombre get
        {
            List<string> listas = new List<string>();
            var Consulta = new ClaseAccesoDatos(); //regresa una nueva cadena de texto 
            var Lista = Consulta.ConsultaPro(id);
            return Json (Lista);
        }

       
        [HttpPost]
        public ActionResult ConsultaProducto() //metodo publico que regresa un arreglo de texto con nombre get
        {
            var Consulta = new ClaseAccesoDatos(); //regresa una nueva cadena de texto 
            var Lista = Consulta.ConsultaTablaP();
            return Json (Lista);
        }
        [HttpPost]
        public ActionResult ConsultaMasV() //metodo publico que regresa un arreglo de texto con nombre get
        {
            var Consulta = new ClaseAccesoDatos(); //regresa una nueva cadena de texto 
            var Lista = Consulta.ConsultaMasV();
            return Json (Lista);
        }
    }

}

