using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRPADS01C1_M2_P1.GustavoFonseca.Domain.Entities;
using System.Data.Entity;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Contexts
{
    public class EntityContextDb : DbContext
    {
        public EntityContextDb()
             : base("name=stringconexao")
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

    }
}
