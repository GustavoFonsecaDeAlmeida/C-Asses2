using GRPADS01C1_M2_P1.GustavoFonseca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories.Interfaces
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Aluno ObterPorMatricula(string matricula);
    }
}
