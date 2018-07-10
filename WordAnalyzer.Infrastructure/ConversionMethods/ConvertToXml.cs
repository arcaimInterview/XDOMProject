using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Infrastructure.ConversionMethods
{
    public static class ConvertToXml
    {
        public static string Go(IEnumerable<Sentence> sentences)
            => new XElement("text",
                    from sentence in sentences
                    select new XElement("sentence",
                        from word in sentence.Words
                        select new XElement("word", word)
                    )).ToString();
    }
}