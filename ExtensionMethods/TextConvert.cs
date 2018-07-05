using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XDOMProject.ExtensionMethods
{
    public static class TextConvert
    {
        public static XElement ToXML(this string text)
        {
            var sentences = text.Split(".");

            return new XElement("text",
                    from sentence in sentences.Where(x => !string.IsNullOrWhiteSpace(x))
                    select
                        new XElement("sentence",
                            from word in sentence.Replace("\n", " ")
                                                 .Replace(",","")
                                                 .Trim()
                                                 .Split(" ")
                                                 .OrderBy(x => x).Where(x => !string.IsNullOrWhiteSpace(x))
                            select new XElement("word", word)
                        )
                );
        }

        public static string ToCSV(this string text)
        {
            var xml = text.ToXML();
            var sentences = xml.Elements("sentence");
            var max = sentences.Select(sen => new 
                                    { WordsNumber = sen.Elements("word").Count() })
                                .Max(x => x.WordsNumber);

            StringBuilder csv = new StringBuilder();

            for (int i = 1; i <= max; i++)
                csv.Append($", Word {i}");
            csv.AppendLine();

            int j = 1;
            foreach(var sen in sentences)
            {
                csv.AppendLine($"Sentence {j++}, " + string.Join(", ", sen.Elements("word").Select(x => x.Value)));
            }

            return csv.ToString();
        }
    }
}