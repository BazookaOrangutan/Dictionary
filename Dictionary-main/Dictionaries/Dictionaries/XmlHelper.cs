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
            
            if (dictionaryElement?.Elements(word).Count() == 0) // Если word еще нет в файле
            {
                wordElement = new XElement(word);
                dictionaryElement?.Add(wordElement);
            }
            else // Если есть
            {
                wordElement = dictionaryElement.Element(word);
            }
            wordElement?.Add(new XElement("translate", translate));
            xdoc.Save(path);
        }

        public static void RemoveWord(string path, string word)
        {
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc.Element("dictionary");
            var wordElement = dictionaryElement.Element(word);
            if (wordElement != null)
            {
                wordElement.Remove();
            }
            xdoc.Save(path);
        }

        public static void ReplaceWord(string path, string oldWord, string newWord)
        {
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc.Element("dictionary");
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
