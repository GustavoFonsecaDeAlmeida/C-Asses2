using GRPADS01C1_M2_P1.GustavoFonseca.Services.Logger.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Services.Logger.Class
{
    public class FileLogger : IFileLogger
    {
        public string DataHora()
        {
            DateTime date = DateTime.Now;
            string format = "yyyyMMdd-HHmmss";
            return date.ToString(format);
        }

        public void Mensagem(string message, string dataHora)
        {
            string filePath = @"../../../Data/esporte-alunos-log-de-carga-" + dataHora + ".txt";


            using (Stream saida = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter escritor = new StreamWriter(saida);

                escritor.BaseStream.Seek(0, SeekOrigin.End);
                escritor.WriteLine(message);

                escritor.Close();
                saida.Close();
            }


        }

    }
}
