using System.Collections.Generic;

namespace TddFromTheScratchWeb.Models
{
    public class ProcessResultModel
    {
        public string Filename { get; set; }
        public int FileNumber { get; set; }
        public List<ProcessResultItemModel> Items { get; set; }

    }
}
