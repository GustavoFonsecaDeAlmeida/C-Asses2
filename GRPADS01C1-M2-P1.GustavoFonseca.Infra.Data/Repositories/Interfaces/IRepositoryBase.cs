using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(Guid? id);
        void Adicionar(T obj);
        void Atualizar(T obj);
        void Remover(T obj);
    }
}
