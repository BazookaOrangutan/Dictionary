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
        //public XmlHelper(string name) 
        //{
        //    var xdoc = new XDocument();
        //    var dictionaryXml = new XElement("dictionary");
        //    xdoc.Add(dictionaryXml);
        //    xdoc.Save($"{name}.xml");
        //}
    }
}
