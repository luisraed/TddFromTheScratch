using System.Collections.Generic;

namespace TddFromTheScratch.Business
{
    public class ProcessFileResult
    {
        public int FileNumber { get; set; }

        public List<ProcessResultItem> Items { get; set; }
    }
}
