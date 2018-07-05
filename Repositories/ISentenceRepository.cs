using System;
using System.Collections.Generic;
using XDOMProject.Models;

namespace XDOMProject.Repositories
{
    public interface ISentenceRepository
    {
        void Add(Sentence sentence);
        IEnumerable<Sentence> GetAll();
    }
}