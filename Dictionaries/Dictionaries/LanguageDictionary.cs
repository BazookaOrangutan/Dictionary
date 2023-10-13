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
        public void AddWord(W word, string translate)
        {
            dictionary[word].Add(translate); 
        }
        public void RemoveWord(W word)
        {
            dictionary.Remove(word);
        }
        public void ReplaceWord(W oldWord, W newWord)
        {
            dictionary[newWord] = dictionary[oldWord];
            dictionary.Remove(oldWord);
        }


    }
}
