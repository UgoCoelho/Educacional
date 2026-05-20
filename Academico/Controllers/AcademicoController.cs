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
            aluno.Id = (alunos != null && alunos.Any()) ? alunos.Max(a => a.Id) + 1 : 1;

            alunos.Add(aluno);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) 
        {
            if(id == null)
            {
                return NotFound();
            }

            return View(alunos.Where(a => a.Id == id).FirstOrDefault());       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Aluno aluno)
        {
            alunos.Remove(alunos.Where(a => a.Id == aluno.Id).FirstOrDefault());
            alunos.Add(aluno);
            return RedirectToAction("Index");
               

        }


        // GET
        public IActionResult Delete(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            alunos.Remove(aluno);

            return RedirectToAction(nameof(Index));
        }

        ///sem tela de confirmação
        /*
         * public IActionResult Delete(int id)
            {
                var aluno = alunos.FirstOrDefault(a => a.Id == id);

                if (aluno == null)
                {
                    return NotFound();
                }

                alunos.Remove(aluno);

                return RedirectToAction(nameof(Index));
            }
         */

    }
}
