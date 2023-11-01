using Dictionaries;
using System.IO;
using System.Xml.Linq;



//while (true)
//{

//    Console.Clear();
//    Console.WriteLine("Введите название словаря, чтобы открыть существующий или создать новый");
//    var path = Console.ReadLine() + ".xml";
//    if (!dictionariesCollection.Contains(path))
//        XDictionaries.CreateXml(path);
//    while (flag)
//    {
//        Console.Clear();
//        Console.WriteLine($"Словарь {path}");
//    }

//}

//var dictionariesXml = new XDocument();
//dictionariesXml?.Add(new XElement("dictionaries"));
//dictionariesXml.Save("dictionaries.xml");



//var xdoc = XDocument.Load("test1.xml");
//xdoc.Save("test1.xml");
//xdoc.Save("test1.xml");

#region Простое меню
var dictionariesXml = XDocument.Load("dictionaries.xml");
var dictionariesElement = dictionariesXml?.Element("dictionaries");
var dictionariesCollection = new List<string>();
dictionariesCollection.Add("1.Создать словарь");
foreach (var dictionarie in dictionariesElement?.Elements())
{
    dictionariesCollection.Add($"{dictionariesCollection.Count+1}.{dictionarie.Name}");
}
dictionariesCollection.Add($"{dictionariesCollection.Count+1}.Выход");
var dcLength = dictionariesCollection?.Count ?? 0;
var flag = false;
string path = string.Empty;
var menuItems = new List<string> { "1.Добавить перевод", "2.Удалить слово из словаря", "3.Изменить слово",
    "4.Удалить один из переводов слова", "5.Изменить перевод слова", "6.Найти перевод слова", "7.Экспортировать словарь", "8.Назад" };

//Console.WriteLine("Создайте новый словарь или выберите существующий");
//Console.WriteLine();

while (true)
{
    while (flag)
    {
        Console.Clear();
        Console.WriteLine($"Словарь {path.Substring(0, path.Length - 4)}\n");

        
        DrawMenu(menuItems);
        var numberStr2 = Console.ReadLine();
        int number2;
        try
        {
            number2 = int.Parse(numberStr2);
        }
        catch
        {
            number2 = -1; 
        }
        
        Console.WriteLine();
        switch (number2)
        {
            case 1: //AddWord
              
                Console.Write("Введите слово: ");
                var word = Console.ReadLine();
                Console.Write("\nВведите перевод: ");
                var translate = Console.ReadLine();
                try
                {
                    XDictionaries.AddWord(path, word, translate);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("\n"+ex.Message);
                    Console.ReadKey();
                } 

                break;
            case 2: //RemoveWord

                Console.Write("Введите слово: ");
                word = Console.ReadLine();

                XDictionaries.RemoveWord(path, word);
                break;
            case 3: //ReplaceWord

                Console.Write("Введите слово, которое нужно заменить: ");
                var oldWord = Console.ReadLine();
                Console.Write("\nВведите новое слово: ");
                var newWord = Console.ReadLine();
                try
                {
                    XDictionaries.ReplaceWord(path, oldWord, newWord);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("\n"+ex.Message);
                    Console.ReadKey();
                }
                
                break;
            case 4: //RemoveTranslate

                Console.Write("Введите слово: ");
                word = Console.ReadLine() ;
                Console.Write("\nВведите перевод, который нужно удалить: ");
                translate = Console.ReadLine() ;
                try
                {
                    XDictionaries.RemoveTranslate(path, word, translate);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.ReadKey();
                }
                break;
            case 5: //ReplaceTranslate
                 
                Console.Write("Введите слово: ");
                word = Console.ReadLine();
                Console.Write("\nВведите перевод, который нужно заменить: ");
                var oldTranslate = Console.ReadLine();
                Console.Write("\nВведите новый перевод: ");
                var newTranslate = Console.ReadLine();
                try
                {
                    XDictionaries.ReplaceTranslate(path, word, oldTranslate, newTranslate);
                }
                catch(Exception ex)
                { 
                    Console.WriteLine("\n" + ex.Message); 
                    Console.ReadKey();
                }
                break;
            case 6: //Search

                Console.Write("Введите слово: ");
                word = Console.ReadLine();
                try
                {
                    Console.WriteLine(XDictionaries.Search(path, word));
                }
                catch(Exception ex) { Console.WriteLine("\n" + ex.Message); }
                Console.ReadKey();
                break;
            case 7:
                Console.Write("Укажите имя файла: ");
                var name = Console.ReadLine();
                
                XDictionaries.Export(path, name+".txt");
                break;
            case 8: //Back
                flag = false;
                break;
            default:
                Console.WriteLine("\nПункта с таким номером нет");
                Console.ReadKey();
                break;
        }

    }
    Console.Clear();
    Console.WriteLine("Создайте новый словарь или выберите существующий\n");

    DrawMenu(dictionariesCollection);
    //var number1 = int.Parse(Console.ReadLine());
    var numberStr1 = Console.ReadLine();
    int number1;
    try
    {
        number1 = int.Parse(numberStr1);
    }
    catch
    {
        number1 = -1;
    }
    Console.WriteLine(); 
    if (number1 == dictionariesCollection.Count) return;
    else if (number1 == 1)
    {
        Console.WriteLine("Введите название словаря: ");
        path = Console.ReadLine() + ".xml";

        dictionariesCollection.Remove($"{dictionariesCollection.Count}.Выход");
        dictionariesCollection.Add($"{dictionariesCollection.Count + 1}." + path);
        dictionariesCollection.Add($"{dictionariesCollection.Count + 1}.Выход");

        dictionariesElement?.Add(new XElement(path));
        dictionariesXml?.Save("dictionaries.xml");
        XDictionaries.CreateXml(path);
        flag = true;
    }
    else if (number1 > 1 && number1 <= dictionariesCollection.Count)
    {
        flag = true;
        path = dictionariesCollection[number1 - 1].Substring(2);
    }
    else
    {
        Console.WriteLine($"\nПункта {numberStr1} не существует");
        Console.ReadKey();
    }
    
}
static void DrawMenu(List<string> items)
{
    for (int i = 0; i < items.Count; i++)
    {
        Console.WriteLine(items[i]);
    }
    Console.WriteLine();
    Console.Write("Поле ввода: ");
}

#endregion


















//var dictionariesXml = XDocument.Load("dictionaries.xml");
//var dictionariesElement = dictionariesXml?.Element("dictioanaries");
//var dictionariesCollection = new List<string>();
//foreach (var dictionarie in dictionariesXml?.Element("dictionaries")?.Elements())
//{
//    dictionariesCollection.Add(dictionarie.Value);
//}
//dictionariesCollection.Add("Создать словарь");
//dictionariesCollection.Add("Выход");
//var dcLength = dictionariesCollection?.Count ?? 0;
//var flag = false;
//string path;
//var menuItems = new List<string> { "1.Добавить перевод", "2.Удалить слово из словаря", "3.Изменить слово",
//    "4.Удалить один из переводов слова", "5.Изменить перевод слова", "6.Найти перевод слова", "Назад" };

//Console.WriteLine("Создайте новый словарь или выберите существующий");
//Console.WriteLine();

//int row = Console.CursorTop;
//int col = Console.CursorLeft;
//int index = 0;
//while (true)
//{
//    while (flag)
//    {
//        DrawMenu(menuItems, row, col, index);
//        switch (Console.ReadKey(true).Key)
//        {
//            case ConsoleKey.DownArrow:
//                if (index < menuItems.Count - 1)
//                    index++;
//                break;
//            case ConsoleKey.UpArrow:
//                if (index > 0)
//                    index--;
//                break;
//            case ConsoleKey.Enter:
//                switch (index)
//                {
//                    case 6:
//                        Console.WriteLine("Выбран выход из приложения");
//                        //return;
//                        flag = false;
//                        Console.Clear();
//                        row = Console.CursorTop;
//                        col = Console.CursorLeft;
//                        Console.WriteLine("Создайте новый словарь или выберите существующий");
//                        Console.WriteLine();
//                        break;
//                    default:
//                        Console.WriteLine($"Выбран пункт {menuItems[index]}");
//                        break;
//                }
//                break;
//        }
//    }



//    DrawMenu(dictionariesCollection, row, col, index);
//    switch (Console.ReadKey(true).Key)
//    {
//        case ConsoleKey.DownArrow:
//            if (index < dictionariesCollection.Count - 1)
//                index++;
//            break;
//        case ConsoleKey.UpArrow:
//            if (index > 0)
//                index--;
//            break;
//        case ConsoleKey.Enter:
//            if (index == dictionariesCollection.Count - 1) return;
//            else if (index == 0)
//            {
//                Console.WriteLine("Введите название словаря: ");
//                path = Console.ReadLine() + ".xml";
//                dictionariesCollection.Add(path);
//                dictionariesElement?.Add(new XElement(path));
//                flag = true;
//            }
//            else
//            {
//                flag = true;
//                path = dictionariesCollection[index];
//            }
//            break;

//    }
//}
//static void DrawMenu(List<string> items, int row, int col, int index)
//{
//    Console.SetCursorPosition(col, row);
//    for (int i = 0; i < items.Count; i++)
//    {
//        if (i == index)
//        {
//            Console.BackgroundColor = Console.ForegroundColor;
//            Console.ForegroundColor = ConsoleColor.Black;
//        }
//        Console.WriteLine(items[i]);
//        Console.ResetColor();
//    }
//    Console.WriteLine();
//}
