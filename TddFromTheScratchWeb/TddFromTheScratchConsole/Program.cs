using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TddFromTheScratch.Business;
using TddFromTheScratchWeb.Controllers;

namespace TddFromTheScratchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing the Controller");

            var actionResult = TestController();

            Console.WriteLine(actionResult.ToString());

            Console.WriteLine("Testing CsvProcessor");

            var processFileResult = TestCsvProcessor();

            Console.WriteLine(processFileResult.FileNumber);
            foreach (var item in processFileResult.Items)
            {
                Console.WriteLine("ClientName:" + item.ClientName + ", SellerCode: " + item.SellerCode);
            }

            Console.ReadKey();
        }

        private static Task<IActionResult> TestController()
        {
            var formFile = new TestFile();

            var fileProcessController = new FileProcessController();

            return fileProcessController.UploadFile(formFile);
        }

        private static ProcessFileResult TestCsvProcessor()
        {
            var csvProcessor = new CsvProcessor();

            return csvProcessor.ProcessFile("process_file.csv");
        }
    }
}
