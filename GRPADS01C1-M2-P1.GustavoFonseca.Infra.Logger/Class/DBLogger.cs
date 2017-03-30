using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class
{
    public class DBLogger : IDBLogger
    {
        public string DataHora()
        {
            DateTime date = DateTime.Now;
            string format = "yyyyMMdd:HHmmss";
            return date.ToString(format);
        }

        public void Mensagem(string message)
        {
            string filePath = @"../../../Data/Logger/DBLogger.txt";

            using (Stream saida = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter escritor = new StreamWriter(saida);

                escritor.BaseStream.Seek(0, SeekOrigin.End);
                escritor.WriteLine($"{DataHora()} - {message}");

                escritor.Close();
                saida.Close();
            }


        }
    }
}
