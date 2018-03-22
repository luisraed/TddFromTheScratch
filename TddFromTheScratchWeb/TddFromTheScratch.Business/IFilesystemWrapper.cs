namespace TddFromTheScratch.Business
{
    public interface IFilesystemWrapper
    {
        bool FileExists(string path);
        string PathCombine(string fileName);
        string[] ReadAlllines(string path);
    }
}
