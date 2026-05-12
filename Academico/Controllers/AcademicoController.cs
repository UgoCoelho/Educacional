using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AcademicoController : Controller

    {
        private static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno { Id = 1, Nome = "UgoLamana", Email = "Coelhou@gmail.com", DataNascimento = new DateTime(2004,07,13)}
        };
        public IActionResult Index()
        {
            return View(alunos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            aluno.Id = alunos.Count + 1;
            alunos.Add(aluno);
            return RedirectToAction("Index");
        }
    }
}
