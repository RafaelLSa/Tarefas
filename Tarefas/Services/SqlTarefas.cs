using System.Collections.Generic;
using System.Linq;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class SqlTarefas : ITarefaData
    {
        private readonly TarefasContext _contexto;

        public SqlTarefas(TarefasContext contexto)
        {
            _contexto = contexto;
        }

        public Tarefa Add(Tarefa tarefa)
        {
            _contexto.Tarefas.Add(tarefa);
            _contexto.SaveChanges();
            return tarefa;
        }

        public Tarefa Get(int id)
        {
            return _contexto.Tarefas.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _contexto.Tarefas.OrderBy(r => r.Detalhes);
        }

        public void Remove(int id)
        {
            Tarefa tarefa = Get(id);
            _contexto.Remove(tarefa);
            _contexto.SaveChanges();
        }

        public Tarefa Update(Tarefa model)
        {
            _contexto.Update(model);
            _contexto.SaveChanges();
            return model;
        }
    }
}
