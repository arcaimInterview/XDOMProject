using System.Collections.Generic;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Core.Repositories;

namespace WordAnalyzer.Infrastructure.Repositories
{
    public class SentenceRepository : ISentenceRepository
    {
        private ISet<Sentence> _sentences = new HashSet<Sentence>();

        public void Add(Sentence sentence)
            => _sentences.Add(sentence);

        public IEnumerable<Sentence> GetAll()
            => _sentences;
    }
}