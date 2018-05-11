using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefas.Models
{
    public class Tarefa
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Este campo precisa contar a descrição da atividade."), MaxLength(200)]
        public String Detalhes { get; set; }
        public DateTime DataLimite { get; set; }
        public Boolean Importante { get; set; }
        public Boolean Concluida { get; set; }
    }
}
