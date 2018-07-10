using Microsoft.AspNetCore.Mvc;
using WordAnalyzer.Core.Domain;
using WordAnalyzer.Infrastructure.ConversionMethods;
using WordAnalyzer.Infrastructure.Services;

namespace WordAnalyzer.Api.Controllers
{
    public class ConvertController : Controller
    {
        readonly ISentenceService _sentenceService;

        public ConvertController(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string XmlConvert([FromForm] TextBox textBox)
        {
            _sentenceService.Load(textBox);
            _sentenceService.SortAsc();
            var sentences = _sentenceService.GetAll();
            return ConvertToXml.Go(sentences);
        }

        [HttpPost]
        public string CsvConvert([FromForm] TextBox textBox)
        {
            _sentenceService.Load(textBox);
            _sentenceService.SortAsc();
            var sentences = _sentenceService.GetAll();
            return ConvertToCsv.Go(sentences);
        }
    }
        
}