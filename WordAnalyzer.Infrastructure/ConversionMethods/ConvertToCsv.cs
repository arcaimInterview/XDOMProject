using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Infrastructure.ConversionMethods
{
    public static class ConvertToCsv // usunąć statiki ze względu na wycieki pamięci
    {
        public static string Go(IEnumerable<Sentence> sentences)
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