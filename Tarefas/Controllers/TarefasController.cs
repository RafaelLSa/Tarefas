using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    [Produces("application/json")]
    [Route("api/Tarefas")]
    public class TarefasController : Controller
    {
        private readonly TarefasContext _contexto;

        public TarefasController( TarefasContext tarefas)
        {
            _contexto = tarefas;
            if (_contexto.Tarefas.Count() == 0)
            {
                _contexto.Tarefas.Add(new Tarefa() { Detalhes = "Encher o tanque!", Concluida = false, Importante = true, DataLimite = new DateTime(2018, 5, 20) });
                _contexto.Tarefas.Add(new Tarefa() { Detalhes = "Pagar VIVO", Concluida = false, Importante = false, DataLimite = new DateTime(2018, 5, 20) });
                _contexto.Tarefas.Add(new Tarefa() { Detalhes = "Buscar Livro com a Vó", Concluida = true, Importante = false });
                _contexto.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Tarefa> GetTodos()
        {
            return _contexto.Tarefas.ToList();
        }

        [HttpGet("{id}", Name = "GetTarefa")]
        public IActionResult GetById(long id)
        {
            var item = _contexto.Tarefas.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] Tarefa item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _contexto.Tarefas.Add(item);
            _contexto.SaveChanges();

            return CreatedAtRoute("GetTarefa", new { id = item.Id }, item);
        }

    }
}