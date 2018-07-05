using System;
using System.Collections.Generic;
using System.Linq;

namespace XDOMProject.Models
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

        public static Sentence Create(string rawSentence, IEnumerable<string> words)
            => new Sentence(rawSentence, words);
    }
}