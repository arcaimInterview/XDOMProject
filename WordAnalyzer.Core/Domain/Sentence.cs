using System.Collections.Generic;

namespace WordAnalyzer.Core.Domain
{
    public class Sentence
    {
    //     public string this [int index] // sam wymyśliłem, pewnie brak zastosowania
    //     {
    //         get { return Words; }
    //     }

        public IEnumerable<string> Words { get; set; }

        public Sentence(IEnumerable<string> words)
        {
            Words = words;
        }
    }
}