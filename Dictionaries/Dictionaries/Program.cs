using Dictionaries;
using System.IO;
using System.Xml.Linq;



//while (true)
//{

//    Console.Clear();
//    Console.WriteLine("Введите название словаря, чтобы открыть существующий или создать новый");
//    var path = Console.ReadLine() + ".xml";
//    if (!dictionariesCollection.Contains(path))
//        XmlHelper.CreateXml(path);
//    while (flag)
//    {
//        Console.Clear();
//        Console.WriteLine($"Словарь {path}");
//    }

//}



var dictionariesXml = new XDocument("dictionaries.xml");
dictionariesXml?.Add(new XElement("dictionaries"));
var dictionariesElement = dictionariesXml?.Element("dictioanaries");
var dictionariesCollection = new List<string>();
foreach (var dictionarie in dictionariesXml?.Element("dictionaries")?.Elements())
{
    dictionariesCollection.Add(dictionarie.Value);
}
dictionariesCollection.Add("Выход");
var dcLength = dictionariesCollection?.Count ?? 0;
var flag = false;
string path;
var menuItems = new List<string> { "1.Добавить перевод", "2.Удалить слово из словаря", "3.Изменить слово", 
    "4.Удалить один из переводов слова", "5.Изменить перевод слова", "6.Найти перевод слова", "Назад" };

Console.WriteLine("Меню");
Console.WriteLine();

int row = Console.CursorTop;
int col = Console.CursorLeft;
int index = 0;
while (true)
{
    while (flag)
    {
        DrawMenu(menuItems, row, col, index);
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.DownArrow:
                if (index < menuItems.Count - 1)
                    index++;
                break;
            case ConsoleKey.UpArrow:
                if (index > 0)
                    index--;
                break;
            case ConsoleKey.Enter:
                switch (index)
                {
                    case 6:
                        Console.WriteLine("Выбран выход из приложения");
                        //return;
                        flag = false;
                        break;
                    default:
                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
                        break;
                }
                break;
        }
    }
    DrawMenu(dictionariesCollection, row, col, index);
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.DownArrow:
            if (index < dictionariesCollection.Count - 1)
                index++;
            break;
        case ConsoleKey.UpArrow:
            if (index > 0)
                index--;
            break;
        case ConsoleKey.Enter:
            if (index == dictionariesCollection.Count - 1) return;
            else if (index == 0)
            {
                Console.WriteLine("Введите название словаря: ");
                path = Console.ReadLine() + ".xml";
                dictionariesCollection.Add(path);
                dictionariesElement?.Add(new XElement(path));
                flag = true;
            }
            else
            {
                flag = true;
                path = dictionariesCollection[index];
            }
            break;

    }
}
static void DrawMenu(List<string> items, int row, int col, int index)
{
    Console.SetCursorPosition(col, row);
    for (int i = 0; i < items.Count; i++)
    {
        if (i == index)
        {
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.WriteLine(items[i]);
        Console.ResetColor();
    }
    Console.WriteLine();
}
