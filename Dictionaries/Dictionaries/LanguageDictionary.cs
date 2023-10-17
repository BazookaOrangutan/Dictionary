using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    internal class LanguageDictionary<W>
    {
        private Dictionary<W, List<string>> dictionary = new Dictionary<W, List<string>>();
        public string Name { get; init; }
        public void AddWord(W word, string translate)
        {
            dictionary[word].Add(translate); 
        }
        public bool RemoveWord(W word)
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary.Remove(word);
                return true;
            }
            throw new Exception($"Слово \"{word}\" отсутствует в словаре");
                
        }
        public bool ReplaceWord(W oldWord, W newWord)
        {
            if (dictionary.ContainsKey(oldWord))
            {
                dictionary[newWord] = dictionary[oldWord];
                dictionary.Remove(oldWord);
                return true;
            }
            throw new Exception($"Слово \"{oldWord}\" отсутствует в словаре");

        }
        public bool RemoveTranslate(W word, string translate)
        {
            if (dictionary.ContainsKey(word))
            {
                if (dictionary[word].Contains(translate))
                {
                    dictionary[word].Remove(translate);
                    return true;
                }
                throw new Exception($"Слово {word} отсутствует в словаре");
            }
            throw new Exception($"Перевод \"{translate}\" отсутствует у слова {word}");
        }
        public void ReplaceTranslate(W word, string oldTranslate, string newTranslate)
        {
            dictionary[word][dictionary[word].IndexOf(oldTranslate)] = newTranslate;
        }


    }
}
