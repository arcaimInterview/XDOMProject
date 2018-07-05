using Microsoft.AspNetCore.Mvc;
using XDOMProject.ConversionMethods;
using XDOMProject.Models;
using XDOMProject.Services;

namespace XDOMProject.Controllers
{
    public class ConvertController : Controller
    {
        ISentenceService _sentenceService;

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