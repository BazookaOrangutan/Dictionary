using Dictionaries;
using System.Xml.Linq;

var dict = new Dictionary<int, List<string>>()
{
    {1, new List<string>{"Tom", "Tim" } },
    {2, new List<string>{"Tom", "Tim" }},
    {3, new List<string>{"Tom", "Tim" }}
};

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

var dictionary = new LanguageDictionary("test1");
var xdoc = XDocument.Load("test1.xml");
var elem1 = new XElement("elem1", "elemName");
var dictionaryElement = xdoc.Element("dictionary");
dictionaryElement?.Add(elem1);
xdoc.Save("test1.xml");

