using TddFromTheScratch.Business;

namespace TddFromTheScratchWeb.Business
{
    public class FilesystemWrapperFactory
    {
        private static IFilesystemWrapper _filesystemWrapper;
        public static IFilesystemWrapper Create()
        {
            if (_filesystemWrapper == null)
                _filesystemWrapper = new FilesystemWrapper();

            return _filesystemWrapper;
        }

        public static void SetFilesystemWrapper(IFilesystemWrapper filesystemWrapper)
        {
            _filesystemWrapper = filesystemWrapper;
        }
    }
}
