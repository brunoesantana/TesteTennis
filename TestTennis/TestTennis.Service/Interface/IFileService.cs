using System.Collections.Generic;

namespace TesteTennis.Service.Interface
{
    public interface IFileService
    {
        void StartGame(string filePath);

        List<string> ReadFile(string filePath);

        void ProcessFile(List<string> contentList);
    }
}