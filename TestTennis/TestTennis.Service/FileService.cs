using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TesteTennis.CrossCutting;
using TesteTennis.Service.Interface;
using TestTennis.Service;

namespace TesteTennis.Service
{
    public class FileService : IFileService
    {
        public void StartGame(string filePath)
        {
            var contentFile = ReadFile(filePath);
            ProcessFile(contentFile);
        }

        public List<string> ReadFile(string filePath)
        {
            try
            {
                var contentList = new List<string>();
                var file = new StreamReader(filePath);

                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    contentList.Add(line);
                }

                file.Close();

                return contentList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ProcessFile(List<string> contentList)
        {
            var server = contentList.ElementAt(ConstantUtil.ZERO);
            var receiver = contentList.ElementAt(ConstantUtil.ONE);

            Console.WriteLine($"Jogadores Selecionados para a partida: {server} x {receiver}");
            Console.WriteLine($"Server: {server}");
            Console.WriteLine($"Receiver: {receiver}");

            var game = new GameService(server, receiver);
            var result = game.ShowScore();

            foreach (var item in contentList)
            {
                if (!item.Contains(server) && !item.Contains(receiver))
                {
                    if (result.Contains(ConstantUtil.WINNER))
                    {
                        Console.WriteLine(game.ShowScore());
                        return;
                    }

                    if (item.ToLower().Contains(ConstantUtil.SERVER_SCORES))
                    {
                        game.ServerScoresPoint();
                        result = game.ShowScore();
                        Console.WriteLine(result);
                    }

                    if (item.ToLower().Contains(ConstantUtil.RECEIVER_SCORES))
                    {
                        game.ReceiverScoresPoint();
                        result = game.ShowScore();
                        Console.WriteLine(result);
                    }
                }
            }

            if (!result.Contains("Winner"))
            {
                var finalScore = result.Split(":").ToList();
                var finalDescription = finalScore.FirstOrDefault().ToString() == finalScore.LastOrDefault().ToString() ? ConstantUtil.DEUCE : ConstantUtil.UNFINISHED;

                Console.WriteLine($"Final Result: {finalDescription} - {game.ShowScore()}");
            }
        }
    }
}