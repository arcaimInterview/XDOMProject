using System.Collections.Generic;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Core.Repositories;
using WordAnalyzer.Infrastructure.Sorts;

namespace WordAnalyzer.Infrastructure.Converters
{
    public abstract class Converter
    {
        protected IEnumerable<Sentence> _sentences;
        public void LoadSentences(IEnumerable<Sentence> sentences)
            => _sentences = sentences;

        public string ConvertToStructure()
            => CreateStructure(_sentences);

        protected abstract string CreateStructure(IEnumerable<Sentence> senteces);
    }
}