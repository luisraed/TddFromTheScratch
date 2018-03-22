using System.Collections.Generic;
using System.IO;

namespace TddFromTheScratch.Business
{
    public class CsvProcessor
    {
        public CsvProcessor()
        {

        }

        public ProcessFileResult ProcessFile(string fileName)
        {
            var processFileResult = new ProcessFileResult {
                Status = Enumerations.ProcessFileStatuses.Error,
                Items = new List<ProcessResultItem>()
            };

            if (string.IsNullOrEmpty(fileName))
                return processFileResult;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

            if (!File.Exists(path))
               return processFileResult;

            var fileLines = File.ReadAllLines(path);

            processFileResult.FileNumber = int.Parse(fileLines[0].Substring(12, 6));

            for (var i=2; i<fileLines.Length; i++)
            {
                var lineValues = fileLines[i].Split(',');
                processFileResult.Items.Add(new ProcessResultItem()
                {
                    Subsidiary = lineValues[0],
                    SellerCode = lineValues[1],
                    ClientName = lineValues[2],
                    ProductCode = lineValues[3],
                    ProductDescription = lineValues[4],
                    ProductQuantity = int.Parse(lineValues[5]),
                    ProductPrice = decimal.Parse(lineValues[6]),
                    Total = decimal.Parse(lineValues[7])
                });
            }

            return processFileResult;
        }
    }
}
