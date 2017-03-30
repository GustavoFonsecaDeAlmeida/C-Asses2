using GRPADS01C1_M2_P1.GustavoFonseca.Services.XML.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Services.XML.Class
{
    public class ArquivoXML : IArquivoXML
    {
        public string Nome { get; set; }
        public string Path { get; set; }

        public ArquivoXML(string nome)
        {
            Nome = nome;
            Path = @"../../../Data/";
        }

        public string Carregar()
        {
            return Path + Nome + ".xml";
        }

        public void Renomear(string novoNome)
        {
            string atual = Path + Nome + ".xml";
            string novo = Path + novoNome + ".xml";
            File.Move(atual, novo);
            Nome = novoNome;
        }
    }
}
