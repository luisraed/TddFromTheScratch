using System.IO;

namespace TddFromTheScratch.Business
{
    public class FilesystemWrapper : IFilesystemWrapper
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string PathCombine(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
        }

        public string[] ReadAlllines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
