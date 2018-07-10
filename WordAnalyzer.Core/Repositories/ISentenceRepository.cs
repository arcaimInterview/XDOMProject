using System.Collections.Generic;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Core.Repositories
{
    public interface ISentenceRepository
    {
        void Add(Sentence sentence);
        IEnumerable<Sentence> GetAll();
    }
}