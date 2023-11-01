using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dictionaries
{
    internal static class XDictionaries
    {
        public static void CreateXml(string path)
        {
            var xdoc = new XDocument();
            var dictionaryXml = new XElement("dictionary");
            xdoc?.Add(dictionaryXml);
            //xdoc?.Save($"{name}.xml");
            xdoc?.Save(path);
        }

        public static void AddWord(string path, string word, string translate)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(translate))
                throw new Exception("Предупреждеие: Нельзя записать пустое слово или пустой перевод");
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc?.Element("dictionary");
            XElement? wordElement;

            var flag = true;
            if (dictionaryElement?.Elements(word)?.Count() == 0) // Если word еще нет в файле
            {
                wordElement = new XElement(word);
                dictionaryElement?.Add(wordElement);
            }
            else // Если есть
            {
                wordElement = dictionaryElement?.Element(word);
                foreach(var item in wordElement?.Elements())
                {
                    if(item.Value == translate)
                        flag= false;
                }
            }
            if(flag) 
                wordElement?.Add(new XElement("translate", translate));
            xdoc?.Save(path);
        }

        public static void RemoveWord(string path, string word)
        {
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc?.Element("dictionary");
            var wordElement = dictionaryElement?.Element(word);
            wordElement?.Remove();
            xdoc?.Save(path);
        }

        public static void ReplaceWord(string path, string oldWord, string newWord)
        {
            if (string.IsNullOrEmpty(oldWord) || string.IsNullOrEmpty(newWord))
                throw new Exception("Предупреждеие: Нельзя изменить или записать пустое слово");
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc?.Element("dictionary");
            var oldWordElement = dictionaryElement?.Element(oldWord);
            var newWordElement = dictionaryElement?.Element(newWord);
            if(oldWordElement != null)
            {
                if (newWordElement != null)
                {

                    oldWordElement.Add(newWordElement.Elements());
                    foreach (var item in oldWordElement.Elements())
                    {
                        if (oldWordElement?.Elements(item.Name).Count() > 1)
                        {
                            item?.Remove();
                        }
                    }
                    newWordElement?.Remove();
                }
                oldWordElement.Name = newWord;
            }
            xdoc?.Save(path);
        }

        public static void RemoveTranslate(string path, string word, string translate)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception("Предупреждеие: Нельзя удалить перевод из пустого слова");
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc?.Element("dictionary");
            var wordElement = dictionaryElement?.Element(word);
            if (wordElement?.Elements().Count() > 1) 
            { 
                 wordElement?.Elements("translate")?
                    .Where(t => t.Value == translate)
                    .Remove();
            }
            xdoc?.Save(path);
        }

        public static void ReplaceTranslate(string path, string word, string oldTranslate, string newTranslate)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(oldTranslate) || string.IsNullOrEmpty(newTranslate))
                throw new Exception("Предупреждеие: Нельзя изменить или записать пустые слово и перевод");
            if (oldTranslate != newTranslate)
            {
                var xdoc = XDocument.Load(path);
                var dictionaryElement = xdoc?.Element("dictionary");
                var wordElement = dictionaryElement?.Element(word);
                var translateElement = wordElement?.Elements("translate")?
                    .Where(t => t.Value == oldTranslate).First();
                foreach(var item in wordElement?.Elements())
                {
                    if (item.Value == newTranslate) item?.Remove();
                }
                if (translateElement != null)
                {
                    translateElement.Value = newTranslate; 
                }
                xdoc?.Save(path);
            }
            
        }
        
        public static string Search(string path, string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception("Предупреждеие: Нельзя найти перевод пустого слова");
            var xdoc = XDocument.Load(path);
            var translates = xdoc?.Element("dictionary")?.Element(word)?.Elements("translate");
            if(translates != null)
            {
                string str = $"{word} - ";
                foreach(var item in translates)
                {
                    str += item.Value + "; ";
                }
                return str;
            }
            else
                throw new Exception($"Слово {word} отсутствует в словаре");


        }

        public static void Export(string path, string filename)
        {
            using var writer = new StreamWriter(filename);
            var xdoc = XDocument.Load(path);
            var dictionaryElement = xdoc.Element("dictionary");
            writer.WriteLine($"Словарь \"{path.Substring(0, path.Length-4)}\"");
            foreach(var word in dictionaryElement.Elements())
            {
                writer.Write($"{word.Name} - ");
                foreach(var translate in word.Elements())
                {
                    writer.Write($" {translate.Value};");
                }
                writer.WriteLine();
            }
        }


    }
}
