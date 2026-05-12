using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class ExemploController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
