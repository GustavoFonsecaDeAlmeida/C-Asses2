using GRPADS01C1_M2_P1.GustavoFonseca.Infra.XML.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Infra.XML.Class
{
    public static class ControllerXML
    {
        private static XmlDocument xml = null;
        private static XmlNodeList xnList = null;

        public static void CarregarXML(IArquivoXML arquivo)
        {
            xml = new XmlDocument();
            xml.Load(arquivo.Carregar());
        }

        public static XmlNodeList LerXML(string tagElemento)
        {
            return xml.GetElementsByTagName(tagElemento);
        }

    }
}
