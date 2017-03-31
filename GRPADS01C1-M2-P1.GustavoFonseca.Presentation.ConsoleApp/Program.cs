using GRPADS01C1_M2_P1.GustavoFonseca.Domain.Entities;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories.Interfaces;

using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Logger.Class.Interfaces;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.XML.Class;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.XML.Class.Interfaces;
using System;
using System.Xml;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Presentation.ConsoleApp
{
    class Program
    {
        private static readonly IAlunoRepository _alunoRepository = new AlunoRepository();
        private static readonly IFileLogger _logger = new FileLogger();

        static void Main(string[] args)
        {

            Console.WriteLine("Iniciando...");
            string dataHora = _logger.DataHora();
            processarXml(dataHora);

            Console.WriteLine("Concluido por favor digite uma tecla para sair");
            Console.ReadKey();

        }

        private static bool parseStringToBool(string val)
        {
            return Convert.ToBoolean(Convert.ToInt32(val));
        }

        public static void processarXml(string dataHora)
        {

            IArquivoXML arquivo1 = new ArquivoXML("esporte-alunos");
            ControllerXML.CarregarXML(arquivo1);

            XmlNodeList listaAlunos = ControllerXML.LerXML("aluno");


            for (int i = 0; i < listaAlunos.Count; i++)
            {

                Aluno aluno = new Aluno()
                {
                    Nome = listaAlunos[i]["nome"].InnerText,
                    CPF = listaAlunos[i]["cpf"].InnerText,
                    Nascimento = Convert.ToDateTime(listaAlunos[i]["datadenascimento"].InnerText),
                    Matricula = listaAlunos[i]["matricula"].InnerText,
                    Ativo = parseStringToBool(listaAlunos[i]["ativo"].InnerText)
                };

                Aluno alunoDB = _alunoRepository.ObterPorMatricula(aluno.Matricula);

                if (alunoDB != null)
                {
                    if (aluno.Ativo != alunoDB.Ativo)
                    {
                        alunoDB.Ativo = aluno.Ativo;
                        _alunoRepository.Atualizar(alunoDB);

                        _logger.Mensagem($"matricula>{aluno.Matricula}; nome>{aluno.Nome}; ativo>{!aluno.Ativo}; Alterado: ativo>{aluno.Ativo}", dataHora);
                    }
                    else
                    {
                        _logger.Mensagem($"matricula>{aluno.Matricula}; nome>{aluno.Nome}; ativo>{aluno.Ativo}; OK", dataHora);

                    }

                }
                else
                {

                    _alunoRepository.Adicionar(aluno);
                    _logger.Mensagem($"matricula>{aluno.Matricula}; nome>{aluno.Nome}; ativo>{aluno.Ativo}; Adicionado", dataHora);
                }

            }

            arquivo1.Renomear(arquivo1.Nome + "-" + dataHora);
        }
    }
}

