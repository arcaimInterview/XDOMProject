using System.Collections.Generic;

namespace WordAnalyzer.Core.Domain
{
    public class Sentence
    {
        public string RawSentence { get; set; }
        public IEnumerable<string> Words { get; set; }

        protected Sentence()
        {
        }

        private Sentence(string rawSentence, IEnumerable<string> words)
        {
            RawSentence = rawSentence;
            Words = words;
        }

        public static Sentence Create(string rawSentence, IEnumerable<string> words) // Użyć wzorzec Factory
            => new Sentence(rawSentence, words);
    }
}