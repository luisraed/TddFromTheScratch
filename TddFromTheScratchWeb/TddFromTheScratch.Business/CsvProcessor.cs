using System.Collections.Generic;
using TddFromTheScratchWeb.Business;

namespace TddFromTheScratch.Business
{
    public class CsvProcessor
    {
        private IFilesystemWrapper _filesystemWrapper;

        public CsvProcessor()
        {
            _filesystemWrapper = FilesystemWrapperFactory.Create();
        }

        public CsvProcessor(IFilesystemWrapper filesystemWrapper)
        {
            _filesystemWrapper = filesystemWrapper;
        }

        public IFilesystemWrapper FilesystemWrapper
        {
            get
            {
                if (_filesystemWrapper == null)
                    _filesystemWrapper = new FilesystemWrapper();
                return _filesystemWrapper;
            }
            set
            {
                _filesystemWrapper = value;
            }
        }

        public ProcessFileResult ProcessFile(string fileName)
        {
            var processFileResult = new ProcessFileResult {
                Status = Enumerations.ProcessFileStatuses.Error,
                Items = new List<ProcessResultItem>()
            };

            if (string.IsNullOrEmpty(fileName))
                return processFileResult;

            var path = _filesystemWrapper.PathCombine(fileName);

            if (!_filesystemWrapper.FileExists(path))
               return processFileResult;

            var fileLines = _filesystemWrapper.ReadAlllines(path);

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
