using Microsoft.AspNetCore.Mvc;

namespace Uc_4_Antonia_Clinica.Controllers
{
    public class Notificacao : Controller
    {
        public IActionResult AvisoConsulta()
        {
            return View();
        }
        public IActionResult Lembrete()
        {
            return View();
        }

        public IActionResult Mapa()
        {
            return View();
        }
    }
}
