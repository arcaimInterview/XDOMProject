using System.Collections.Generic;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Infrastructure.Sorts
{
    public interface ISort
    {
        void Run(IEnumerable<Sentence> sentences);
    }
}