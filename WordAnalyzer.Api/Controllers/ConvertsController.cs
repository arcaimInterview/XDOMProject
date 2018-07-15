using Microsoft.AspNetCore.Mvc;
using WordAnalyzer.Infrastructure.Commands;
using WordAnalyzer.Infrastructure.Converters;
using WordAnalyzer.Infrastructure.Services;
using WordAnalyzer.Infrastructure.Sorts;

namespace WordAnalyzer.Api.Controllers
{
    public class ConvertsController : Controller
    {
        readonly ISentenceService _sentenceService;

        public ConvertsController(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Load([FromForm] LoadText command)
            => _sentenceService.Load(command.Text)
               ? StatusCode(201)
               : StatusCode(204);

        public string ConvertToXml()
        {
            _sentenceService.Sort(new SortAsc());
            return _sentenceService.Convert(new XmlConverter());
            // return xml;
        }

        public string ConvertToCsv()
        {
            _sentenceService.Sort(new SortAsc());
            var csv = _sentenceService.Convert(new CsvConverter());
            return csv;
        }
    }
        
}