using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Core.Repositories;
using WordAnalyzer.Infrastructure.Sorts;

namespace WordAnalyzer.Infrastructure.Converters
{
    public class XmlConverter : Converter
    {
        protected override string CreateStructure(IEnumerable<Sentence> sentences)
        {
            var doc = new XDocument(
                new XDeclaration(version: "1.0", encoding: "utf-8", standalone: "yes"),
                new XElement("text",
                        from sentence in sentences
                        select new XElement("sentence",
                            from word in sentence.Words
                            select new XElement("word", word)
                        )));
            var xml = new StringWriter();
            doc.Save(xml);
            return xml.ToString();
        }
    }
}