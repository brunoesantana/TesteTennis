using System;
using TesteTennis.CrossCutting;
using TestTennis.Service;
using TestTennis.Service.Interface;

namespace TesteTennis.Service.Builder
{
    public class MatchBuilder
    {
        private IGameService _game;

        private MatchBuilder()
        {
            _game = new GameService(ConstantUtil.PLAYER_SERVER, ConstantUtil.PLAYER_RECEIVER);
        }

        public static MatchBuilder NewInstance()
        {
            return new MatchBuilder();
        }

        public void BuildGame()
        {
            Console.WriteLine($"Jogadores Selecionados para a partida: {_game.Server.Name} x {_game.Receiver.Name}");
            Console.WriteLine($"Server: {_game.Server.Name}");
            Console.WriteLine($"Receiver: {_game.Receiver.Name}");

            Console.WriteLine(_game.ShowScore());

            _game.ServerScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ReceiverScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ServerScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ReceiverScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ServerScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ReceiverScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ServerScoresPoint();
            Console.WriteLine(_game.ShowScore());

            _game.ServerScoresPoint();
            Console.WriteLine(_game.ShowScore());
        }
    }
}