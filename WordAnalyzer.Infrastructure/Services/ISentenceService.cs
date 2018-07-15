using System.Collections.Generic;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Infrastructure.Commands;
using WordAnalyzer.Infrastructure.Converters;
using WordAnalyzer.Infrastructure.Sorts;

namespace WordAnalyzer.Infrastructure.Services
{
    public interface ISentenceService
    {
        string Convert(Converter converter);
        bool Load(string text);
        
        void Sort(ISort sort);
    }
}