using System.Collections.Generic;
using WordAnalyzer.Core.Domain;

namespace WordAnalyzer.Infrastructure.Services
{
    public interface ISentenceService
    {
        IEnumerable<Sentence> GetAll();
        void Load(TextBox textBox);
        
        void SortAsc();
        void SortDesc();
    }
}