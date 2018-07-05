using System;
using System.Collections.Generic;
using System.Linq;
using XDOMProject.Models;

namespace XDOMProject.Repositories
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