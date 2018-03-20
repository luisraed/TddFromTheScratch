using System.Collections.Generic;
using TddFromTheScratch.Business.Enumerations;

namespace TddFromTheScratch.Business
{
    public class ProcessFileResult
    {
        public int FileNumber { get; set; }

        public ProcessFileStatuses Status { get; set; }

        public List<ProcessResultItem> Items { get; set; }
    }
}
