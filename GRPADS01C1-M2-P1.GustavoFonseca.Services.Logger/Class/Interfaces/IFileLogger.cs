using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Services.Logger.Class.Interfaces
{
    public interface IFileLogger
    {
        string DataHora();
        void Mensagem(string message, string dataHora);
    }
}
