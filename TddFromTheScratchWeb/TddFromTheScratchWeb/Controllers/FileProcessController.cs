using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TddFromTheScratch.Business;
using TddFromTheScratchWeb.Models.Mappers;

namespace TddFromTheScratchWeb.Controllers
{
    public class FileProcessController : Controller
    {
        private readonly FileUploader _fileUploader;
        private readonly CsvProcessor _csvProcessor;
        private readonly ProcessFileResultMapper _processFileResultMapper;

        public FileProcessController()
        {
            _fileUploader = new FileUploader();
            _csvProcessor = new CsvProcessor();
            _processFileResultMapper = new ProcessFileResultMapper();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var path = await _fileUploader.UploadFileAsync(file);

            var processFileResult = _csvProcessor.ProcessFile(path);

            var processFileResultModel = _processFileResultMapper.Map(processFileResult);

            return View(processFileResultModel);
        }
    }
}