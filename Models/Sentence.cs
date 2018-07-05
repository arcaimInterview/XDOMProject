using System;
using System.Collections.Generic;
using System.Linq;

namespace XDOMProject.Models
{
    public class Sentence
    {
        public Guid Id { get; set; }
        public string RawSentence { get; set; }
        public IEnumerable<string> Words { get; set; }

        protected Sentence()
        {
        }

        public Sentence(string rawSentence)
        {
            Id = Guid.NewGuid();
            RawSentence = rawSentence;
            Words = MakeWords(rawSentence);
        }

        public static Sentence Create(string rawSentence)
            => new Sentence(rawSentence);

        private IEnumerable<string> MakeWords(string rawSentence)
            => rawSentence.Replace("\n", " ")
                          .Replace(",","")
                          .Trim()
                          .Split(" ")
                          .Where(x => !string.IsNullOrWhiteSpace(x));
    }
}