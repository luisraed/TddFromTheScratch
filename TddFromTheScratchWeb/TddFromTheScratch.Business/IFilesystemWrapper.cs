namespace TddFromTheScratch.Business
{
    public interface IFilesystemWrapper
    {
        string PathCombine(string fileName);
        bool FileExists(string path);
        string[] ReadAlllines(string path);
    }
}
