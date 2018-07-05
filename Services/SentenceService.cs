using System;
using System.Collections.Generic;
using System.Linq;
using XDOMProject.Models;
using XDOMProject.Repositories;

namespace XDOMProject.Services
{
    public class SentenceService : ISentenceService
    {
        ISentenceRepository _sentenceRepository;

        public SentenceService(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public IEnumerable<Sentence> GetAll()
            => _sentenceRepository.GetAll();

        public void Load(TextBox textBox)
        {
            var sentences = textBox.Text.Split(".");

            foreach(var sen in sentences.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                var words = MakeWords(sen);
                if (!string.IsNullOrWhiteSpace(words.FirstOrDefault()))
                    _sentenceRepository.Add(Sentence.Create(sen, words));
            }
        }

        public void SortAsc()
        {
            var sentences = _sentenceRepository.GetAll();
            foreach (var sen in sentences)
                sen.Words = sen.Words.OrderBy(x => x);
        }

        public void SortDesc()
        {
            var sentences = _sentenceRepository.GetAll();
            foreach (var sen in sentences)
                sen.Words = sen.Words.OrderByDescending(x => x);
        }

        private IEnumerable<string> MakeWords(string rawSentence)
            => rawSentence.Replace("\n", " ")
                          .Replace("\r", " ")
                          .Replace(",","")
                          .Trim()
                          .Split(" ")
                          .Where(x => !string.IsNullOrWhiteSpace(x));
    }
}