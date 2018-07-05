using System;
using System.Collections.Generic;
using XDOMProject.Models;

namespace XDOMProject.Services
{
    public interface ISentenceService
    {
        IEnumerable<Sentence> GetAll();
        void Load(TextBox textBox);
        
        void SortAsc();
        void SortDesc();
    }
}