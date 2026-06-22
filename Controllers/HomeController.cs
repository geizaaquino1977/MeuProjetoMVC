using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using Uc_4_Antonia_Clinica.Data;
using Uc_4_Antonia_Clinica.Models;



namespace Uc_4_Antonia_Clinica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Uc_4_Antonia_ClinicaContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            if (HttpContext.Session.GetString("logado") != "true")
            {
                return RedirectToAction("Index");
            }


            return View();
        }
        public IActionResult Financeiro()
        {
            return View();
        }


        // LOGIN (POST)



        public class LoginModel
        {
            public string usuario { get; set; }
            public string senha { get; set; }
        }

        [HttpPost]
        public JsonResult LoginAjax([FromBody] LoginModel dados)
        {
            if (dados.usuario == "admin" && dados.senha == "123")
            {
                HttpContext.Session.SetString("logado", "true");

                return Json(new { sucesso = true });
            }

            return Json(new { sucesso = false });
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

   
