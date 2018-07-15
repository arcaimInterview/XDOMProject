using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Core.Repositories;
using WordAnalyzer.Infrastructure.Sorts;

namespace WordAnalyzer.Infrastructure.Converters
{
    public class CsvConverter : Converter
    {
        protected override string CreateStructure(IEnumerable<Sentence> sentences)
        {
            var max = sentences.Select(sen => new 
                                    { WordsNumber = sen.Words.Count() })
                                .Max(x => x.WordsNumber);

            var csv = new StringBuilder();

            for (int i = 1; i <= max; i++)
                csv.Append($", Word {i}");
            csv.AppendLine();

            int j = 1;
            
            foreach(var sen in sentences)
            {
                csv.AppendLine($"Sentence {j++}, " + string.Join(", ", sen.Words));
            }

            return csv.ToString();
        }
    }
}