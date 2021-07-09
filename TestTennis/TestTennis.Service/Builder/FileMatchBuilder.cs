using TesteTennis.Service.Interface;

namespace TesteTennis.Service.Builder
{
    public class FileMatchBuilder
    {
        private IFileService _fileService;

        private FileMatchBuilder()
        {
            _fileService = new FileService();
        }

        public static FileMatchBuilder NewInstance()
        {
            return new FileMatchBuilder();
        }

        public void BuildGame(string filePath)
        {
            _fileService.StartGame(filePath);
        }
    }
}