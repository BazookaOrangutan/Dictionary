using Dictionaries;
using System.IO;
using System.Xml.Linq;

//var dict = new Dictionary<int, List<string>>()
//{
//    {1, new List<string>{"Tom", "Tim" } },
//    {2, new List<string>{"Tom", "Tim" }},
//    {3, new List<string>{"Tom", "Tim" }}
//};

//dict[4].Add("1");
//foreach (var item in dict[1])
//{
//    Console.WriteLine(item);
//}

//foreach (var kvp in dict)
//{
//    Console.WriteLine(kvp);
//}

//Console.WriteLine(dict[2].Count);

//XDocument xDoc = new XDocument();

////xDoc = XDocument.Load("people.xml");
//XElement diction = new XElement("dictionary");
//XAttribute type = new XAttribute("type", "dwdwdw");
//diction.Add(type);
//XElement dicts = new XElement("dicts");
//dicts.Add(diction);
//xDoc.Add(dicts);
//xDoc.Save("dicts.xml");
//Console.ReadKey();

//var dictionary = new LanguageDictionary("test1");
//var xdoc = XDocument.Load("test1.xml");
//var elem1 = new XElement("elem1", "elemName");
//var dictionaryElement = xdoc.Element("dictionary");
//dictionaryElement?.Add(elem1);
//xdoc.Save("test1.xml");

//var xdoc = XDocument.Load("test1.xml");
//var dictionaryElement = xdoc.Element("dictionary");
//XElement wordElement;
//// Если word еще нет в файле

//if (dictionaryElement?.Elements("word").Count() == 0)
//{
//    wordElement = new XElement("word");
//    dictionaryElement?.Add(wordElement);
//}
//// Если есть
//else
//{
//    wordElement = dictionaryElement.Element("word");
//}
//wordElement?.Add(new XElement("translate", "rrrr"));
//xdoc.Save("test1.xml");


//var xdoc = XDocument.Load("test1.xml");
//var dictionaryElement = xdoc.Element("dictionary");
//var wordElement = dictionaryElement.Element("word");
//if (wordElement != null)
//{
//    wordElement.Remove();
//}
//xdoc.Save("test1.xml");

//var xdoc = XDocument.Load("test1.xml");
//var dictionaryElement = xdoc.Element("dictionary");
//var oldWordElement = dictionaryElement?.Element("word228");
//if (oldWordElement != null)
//    oldWordElement.Name = "word";
//xdoc.Save("test1.xml");

//var xdoc = XDocument.Load("test1.xml");
//var dictionaryElement = xdoc.Element("dictionary");
//var wordElement = dictionaryElement?.Element("word");
//wordElement?.Elements("translate")?
//    .Where(t => t.Value == "car")
//    .Remove();
//xdoc.Save("test1.xml");

//XmlHelper.ReplaceTranslate("test1.xml", "word", "rrrr", "fffff");
//XmlHelper.AddWord("test1.xml", "word2", "translate1");
//XmlHelper.RemoveTranslate("test1.xml", "word", "rrrr");
//XmlHelper.RemoveWord("test1.xml", "elem1");
//XmlHelper.ReplaceWord("test1.xml", "word", "word1");
//XmlHelper.RemoveTranslate("test1.xml", "word2", "translate1");
//XmlHelper.ReplaceTranslate("test1.xml", "word1", "tra222", "translate1");

//XmlHelper.AddWord("test1.xml", "word1", "translate2");
//XmlHelper.AddWord("test1.xml", "word1", "translate3");
//XmlHelper.AddWord("test1.xml", "word2", "translate");

//Console.WriteLine(XmlHelper.Search("test1.xml", "word1"));

//XmlHelper.ReplaceWord("test1.xml", "word", "word1");
//var path = "test1.xml";
//XmlHelper.RemoveWord(path, "word1");

//XmlHelper.AddWord(path, "word1", "translate1");
//XmlHelper.AddWord(path, "word1", "translate2");
//XmlHelper.AddWord(path, "word1", "translate3");

//XmlHelper.AddWord(path, "word2", "translate1");
//XmlHelper.AddWord(path, "word2", "translate4");
//XmlHelper.AddWord(path, "word2", "translate5");

//XmlHelper.ReplaceWord(path, "word1", "word2");
var dictionariesXml = new XDocument("dictionaries.xml");
dictionariesXml?.Add(new XElement("dictionaries"));
var dictionariesCollection = new List<string>();
foreach(var dictionarie in dictionariesXml?.Element("dictionaries")?.Elements())
{
    dictionariesCollection.Add(dictionarie.Value);
}
var flag = false;
while (true)
{
    if (flag)
    {
        Console.Clear();
    }
    Console.Clear();
    Console.WriteLine("Введите название словаря, чтобы открыть существующий или создать новый");
    var path = Console.ReadLine()+".xml";
    if(!dictionariesCollection.Contains(path))
        XmlHelper.CreateXml(path);

}