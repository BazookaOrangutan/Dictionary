using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dictionaries
{
    internal class LanguageDictionary
    {
        private Dictionary<string, List<string>> _dictionary;
        public string Type { get; init; }

        public LanguageDictionary(string type)
        {
            _dictionary = new Dictionary<string, List<string>>();
            Type = type;
            //var xdoc = new XDocument();
            //var dictionaryXml = new XElement("dictionary");
            //xdoc.Add(dictionaryXml);
            //xdoc.Save($"{Type}.xml");
            XDictionaries.CreateXml(Type);
        }
        public void AddWord(string word, string translate)
        {
            if(!_dictionary.ContainsKey(word)) 
                _dictionary.Add(word, new List<string>());
            _dictionary[word].Add(translate); 
        }
        public bool RemoveWord(string word)
        {
            if (_dictionary.ContainsKey(word))
            {
                _dictionary.Remove(word);
                return true;
            }
            throw new Exception($"Слово \"{word}\" отсутствует в словаре");
                
        }
        public bool ReplaceWord(string oldWord, string newWord)
        {
            if (_dictionary.ContainsKey(oldWord))
            {
                _dictionary[newWord] = _dictionary[oldWord];
                _dictionary.Remove(oldWord);
                return true;
            }
            throw new Exception($"Слово \"{oldWord}\" отсутствует в словаре");

        }
        public bool RemoveTranslate(string word, string translate)
        {
            if (_dictionary.ContainsKey(word))
            {
                if (_dictionary[word].Contains(translate))
                {
                    if (_dictionary[word].Count != 1)
                    {
                        _dictionary[word].Remove(translate);
                        return true;
                    }
                    else throw new Exception($"Нельзя удалить единственный вариянт перевода");
                }
                else throw new Exception($"Перевод \"{translate}\" отсутствует у слова {word}");
            }
            throw new Exception($"Слово {word} отсутствует в словаре");
        }
        public bool ReplaceTranslate(string word, string oldTranslate, string newTranslate)
        {
            if (_dictionary.ContainsKey(word))
            {
                if (_dictionary[word].Contains(oldTranslate))
                {
                    _dictionary[word][_dictionary[word].IndexOf(oldTranslate)] = newTranslate;
                    return true;
                }
                else throw new Exception($"Перевод \"{oldTranslate}\" отсутствует у слова {word}");
            }
            throw new Exception($"Слово {word} отсутствует в словаре");
        }
        public List<string> SearchTranslate(string word)
        {
            if (_dictionary.ContainsKey(word))
            {
                return _dictionary[word];
            }
            throw new Exception($"Слово {word} отсутствует в словаре");
        }

    }
}
