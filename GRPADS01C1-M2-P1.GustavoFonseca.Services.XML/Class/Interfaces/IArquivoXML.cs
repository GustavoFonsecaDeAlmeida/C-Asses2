using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Services.XML.Class.Interfaces
{
    public interface IArquivoXML
    {

        string Nome { get; set; }
        string Path { get; set; }

        string Carregar();
        void Renomear(string novoNome);
    }
}
