using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Domain.Entities
{
    public class Aluno
    {
        [Key]
        public Guid AlunoId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
