using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class.Interfaces
{
    public interface IDBLogger
    {
        string DataHora();
        void Mensagem(string message);
    }
}
