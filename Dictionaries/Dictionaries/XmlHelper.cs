using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dictionaries
{
    internal static class XmlHelper
    {
        public static void CreateXml(string name)
        {
            var xdoc = new XDocument();
            var dictionaryXml = new XElement("dictionary");
            xdoc.Add(dictionaryXml);
            xdoc.Save($"{name}.xml");
        }

        public static void AddWord(string path, string word, string translate)
        {
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc.Element("dictionary");
            XElement wordElement;
            // Если word еще нет в файле

            if (dictionaryElement?.Elements(word).Count() != 0)
            {
                wordElement = new XElement(word);
               
            }
            // Если есть
            else
            {
                wordElement = xdoc.Element(word);
            }
            wordElement?.Add("translate", translate);
            dictionaryElement?.Add(wordElement);

        }
        //public XmlHelper(string name) 
        //{
        //    var xdoc = new XDocument();
        //    var dictionaryXml = new XElement("dictionary");
        //    xdoc.Add(dictionaryXml);
        //    xdoc.Save($"{name}.xml");
        //}
    }
}
