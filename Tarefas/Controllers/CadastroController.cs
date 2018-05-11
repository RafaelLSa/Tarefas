using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Services;
using Tarefas.ViewModels;

namespace Tarefas.Controllers
{
    [Route("[controller]/[action]")]
    public class CadastroController : Controller
    {
        private ITarefaData _tarefasData;

        public CadastroController(ITarefaData tarefasData)
        {
            _tarefasData = tarefasData;
        }

        public IActionResult Index()
        {
            var model = _tarefasData.GetAll();
            return View(model);
        }

        [Route("{id}")]
        public IActionResult Detalhes(int id)
        {
            var model = new TarefaViewModel(_tarefasData.Get(id));
                
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Tarefa model)
        {
            Tarefa novaTarefa = _tarefasData.Add(model);
            return RedirectToAction("Detalhes", new { id = model.Id });
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            _tarefasData.Remove(id);
            return RedirectToAction("Index");
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Alterar(int id)
        {
            var model = new TarefaViewModel(_tarefasData.Get(id));
            return View(model);
        }

        [Route("{id}")]
        [HttpPost]
        public IActionResult Alterar(TarefaViewModel model)
        {

            Tarefa novaTarefa = model.ToTarefa();
            _tarefasData.Update(novaTarefa);
            return RedirectToAction("Detalhes", new { id = model.Id });
        }

    }
}
