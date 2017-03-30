using GRPADS01C1_M2_P1.GustavoFonseca.Domain.Entities;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Contexts;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories.Interfaces;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private static readonly EntityContextDb _db = new EntityContextDb();
        private static readonly IDBLogger _logger = new DBLogger();

        public void Adicionar(Aluno obj)
        {
            try
            {
                _db.Alunos.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.Mensagem(e.Message);
                _logger.Mensagem($"Não foi possível adicionar o aluno: Matricula>{obj.Matricula}; Nome>{obj.Nome}");
            }


        }

        public void Atualizar(Aluno obj)
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.Mensagem($"Não foi possível atualizar o aluno: Matricula>{obj.Matricula}; Nome>{obj.Nome}");
            }
        }



        public Aluno ObterPorId(Guid? id)
        {
            Aluno aluno = null;
            try
            {
                aluno = _db.Alunos.Find(id);
            }
            catch (Exception e)
            {
                _logger.Mensagem($"Não foi possível obter o Aluno com o id: {id}");
            }

            return aluno;
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            Aluno aluno = null;
            try
            {
                aluno = (from c in _db.Alunos where c.Matricula.Equals(matricula) select c).FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.Mensagem($"Não foi possível obter o Aluno com a matricula: {matricula}");
            }

            return aluno;
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            IEnumerable<Aluno> alunos = null;
            try
            {
                alunos = _db.Alunos.ToList();
            }
            catch (Exception e)
            {
                _logger.Mensagem("Não foi possível obter todos os alunos!");
            }

            return alunos;
        }

        public void Remover(Aluno obj)
        {
            try
            {
                _db.Alunos.Remove(obj);
            }
            catch (Exception e)
            {
                _logger.Mensagem($"Não foi possível remover o aluno: Matricula>{obj.Matricula}; Nome>{obj.Nome}");
            }
        }
    }
}
