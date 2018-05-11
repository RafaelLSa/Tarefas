using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.ViewModels
{

    public class TarefaViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Este campo precisa contar a descrição da atividade."), MaxLength(200)]
        public String Detalhes { get; set; }
        public DateTime DataLimite { get; set; }
        public int Importante { get; set; }
        public int Concluida { get; set; }

        public TarefaViewModel()
        {
                
        }

        public TarefaViewModel(Tarefa tarefa)
        {
            this.Detalhes = tarefa.Detalhes;
            this.Concluida = tarefa.Concluida == true ? 1 : 0;
            this.DataLimite = tarefa.DataLimite;
            this.Importante = tarefa.Importante == true ? 1 : 0;
            this.Id = tarefa.Id;
        }

        public Tarefa ToTarefa()
        {
            Tarefa novaTarefa = new Tarefa()
            {
                Id = this.Id,
                Detalhes = this.Detalhes,
                Concluida = this.Concluida == 1 ? true : false,
                Importante = this.Importante == 1 ? true : false,
                DataLimite = this.DataLimite
            };
            return novaTarefa;
        }
    }
}
