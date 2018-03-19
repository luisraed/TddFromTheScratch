using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TddFromTheScratchConsole
{
    public class TestFile : IFormFile
    {
        public string ContentType => "application/vnd.ms-excel";

        public string ContentDisposition => "form-data; name=\"file\"; filename=\"process_file.csv";

        public IHeaderDictionary Headers
        {
            get
            {
                var dict = new Dictionary<string, StringValues>();
                dict["0"] = "form-data; name=\"file\"; filename=\"process_file.csv";
                dict["1"] = "application/vnd.ms-excel";
                return (IHeaderDictionary) dict;
            }
        }

        public long Length => throw new NotImplementedException();

        public string Name => "file";

        public string FileName => "process_file.csv";

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", FileName);
            return new FileStream(path, FileMode.Create);
        }
    }
}
