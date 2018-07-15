using System.Collections.Generic;
using System.Linq;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Infrastructure.Sorts
{
    public class SortAsc : ISort
    {
        public void Run(IEnumerable<Sentence> sentences)
        {
            foreach (var sen in sentences)
                sen.Words = sen.Words.OrderBy(x => x);
        }
    }
}