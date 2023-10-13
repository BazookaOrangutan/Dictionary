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
        public void AddWord(W word, List<string> translate)
        {
            dictionary[word] = translate; 
        }
    }
}
