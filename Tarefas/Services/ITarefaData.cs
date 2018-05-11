using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefaData
    {
        IEnumerable<Tarefa> GetAll();
        Tarefa Get(int id);
        Tarefa Add(Tarefa tarefa);
        void Remove(int id);
        Tarefa Update(Tarefa model);
    }
}
