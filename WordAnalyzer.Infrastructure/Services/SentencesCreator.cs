using System.Collections.Generic;
using System.Linq;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Infrastructure.Services
{
    public class SentencesCreator
    {
        public List<Sentence> Sentences { get; }
        private bool _correctness = true;
        private string _text;

        public SentencesCreator(string text)
        {
            _text = text;
            Sentences = new List<Sentence>();
        }

        public bool Create()
        {
            if (string.IsNullOrWhiteSpace(_text))
                return false; // TODO: Error or Exception?
            
            _text.SplitBy('.')
                 .ToList()
                 .ForEach(x => Sentences
                 .Add(CreateSentence(x)));

            return true;
        }

        private Sentence CreateSentence(string rawSentence)
            => new Sentence(rawSentence.Replace("\n", " ")
                          .Replace("\r", " ")
                          .Replace(",","")
                          .Trim()
                          .SplitBy(' ')
                          .Where(x => !string.IsNullOrWhiteSpace(x)));
    }

    internal static class ExtensionMethods
    {
        public static IEnumerable<string> SplitBy(this string text, char c)
            => text.Split(c)
                   .Where(x => !string.IsNullOrWhiteSpace(x));
    }
}