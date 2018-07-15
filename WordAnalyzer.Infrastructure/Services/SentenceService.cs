using System.Collections.Generic;
using System.Linq;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Core.Repositories;
using WordAnalyzer.Infrastructure.Commands;
using WordAnalyzer.Infrastructure.Converters;
using WordAnalyzer.Infrastructure.Sorts;

namespace WordAnalyzer.Infrastructure.Services
{
    public class SentenceService : ISentenceService
    {
        ISentenceRepository _sentenceRepository;

        public SentenceService(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public string Convert(Converter converter)
        {
            converter.LoadSentences(_sentenceRepository.GetAll());
            return converter.ConvertToStructure();
        }

        public bool Load(string text)
        {
            var creator = new SentencesCreator(text);
            var isCorrect = creator.Create();
            _sentenceRepository.Clear();
            creator.Sentences
                   .ForEach(x => _sentenceRepository.Add(x));
            
            return isCorrect;
        }

        public void Sort(ISort sort)
            => sort.Run(_sentenceRepository.GetAll());
    }
}